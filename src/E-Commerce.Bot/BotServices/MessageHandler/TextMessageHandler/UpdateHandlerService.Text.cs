using E_Commerce.Application.DTOs;
using E_Commerce.Bot.BotServices.MessageSender;
using E_Commerce.Domain.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace E_Commerce.Bot.BotServices
{
    public partial class UpdateHandlerService
    {
        private async Task HandleTextMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var textMessage = update.Message.Text;
            var from = update.Message.From;
            var storageUser = await _clientService.GetClientAsync(from.Id);

            //authentication:agar user null bo'lsa registratsiya qilamiz
            if (storageUser == null)
                storageUser = await Register(botClient, update, from, cancellationToken);

            //authorization:userni stateni topelik
            var state = storageUser.Status;
            if (state == Status.Inactive)
            {
                await SendMessage.ForPhoneNumberRequest(botClient, update, cancellationToken);
                return;
            }
            else if (state == Status.ChangeName)
            {
                if (textMessage != "⬅️ Ortga")
                {
                    await _clientService.UpdateClientNameAsync(from.Id, textMessage);
                    await SendMessage.ForOptionsState(botClient, update, cancellationToken);
                    return;
                }
            }
            else if (state == Status.ChangeNumber)
            {
                if (textMessage != "⬅️ Ortga")
                {
                    await _clientService.UpdateClientPhoneNumberAsync(from.Id, textMessage);
                    await SendMessage.ForOptionsState(botClient, update, cancellationToken);
                    return;
                }
            }
            else if (state == Status.ChangeLanguage)
            {
                var languages = new string[] { "🇺🇿 O'zbekcha", "🇷🇺 Русский", "🇬🇧 English" };
                if (languages.Contains(textMessage))
                {
                    await _clientService.UpdateClientLanguageCodeAsync(from.Id, textMessage);
                    await SendMessage.ForOptionsState(botClient, update, cancellationToken);
                    return;
                }
            }
            else if (state == Status.Grade)
            {
                var feedbackGrades = new string[] { "Hammasi yoqdi ♥️", "Yaxshi ⭐️⭐️⭐️⭐️", "Yoqmadi ⭐️⭐️⭐️", "Yomon ⭐️⭐️", "Juda yomon 👎🏻" };
                if (feedbackGrades.Contains(textMessage))
                {
                    var rateDto = new RateCreationDTO()
                    {
                        UserTelegramId = from.Id,
                        RateText = textMessage
                    };

                    await _rateService.AddRateAsync(rateDto);
                    await _clientService.UpdateClientUserStatusAsync(from.Id, Status.Feedback);
                    await SendMessage.ForFeedbackState(botClient, update, cancellationToken);
                    return;
                }
            }
            else if (state == Status.Feedback)
            {
                var feedback = new Feedback()
                {
                    UserTelegramId = from.Id,
                    Text = textMessage,
                };

                await _feedbackService.AddFeedbackAsync(feedback);
                await _clientService.UpdateClientUserStatusAsync(from.Id, Status.Active);
                await SendMessage.ForMainState(botClient, update, cancellationToken);
                return;
            }
            else if(state == Status.Information) 
            {
                if (textMessage != "⬅️ Ortga")
                {
                    var branch = await _branchService.GetBranchFromNameAsync(textMessage);
                    if (branch == null)
                    {
                        await SendMessage.InformationNotFound(botClient,update,cancellationToken);
                        return;
                    }

                    await SendMessage.ForBranchState(botClient,update, cancellationToken, branch);
                }
            }


            var texthandler = textMessage switch
            {
                "/start" => CommandForPhoneNumberRequest(botClient, update, cancellationToken),
                "⬅️ Ortga" => CommandForPreviousRequest(botClient, update, cancellationToken, state),
                "☎️ Biz bilan aloqa" => CommandForContactRequest(botClient, update, cancellationToken),
                "✍️ Fikr bildirish" => CommandForFeedbackRequest(botClient, update, cancellationToken),
                "⚙️ Sozlamalar" => CommandForOptionsRequest(botClient, update, cancellationToken),
                "Ismni o'zgartirish" => CommandForChangeNameRequest(botClient, update, cancellationToken),
                "Raqamni o'zgartirish" => CommandForChangeNumberRequest(botClient, update, cancellationToken),
                "🇺🇿 Tilni tanlang" => CommandForChangeLanguageRequest(botClient, update, cancellationToken),
                "ℹ️ Ma'lumot" => CommandForInformationRequest(botClient, update, cancellationToken, new List<string> { "Kukcha" }),
                //refactor qilinmaganlari
                "🛍 Buyurtma berish" => SendMessage.ForOrdersState(botClient, update, cancellationToken),
                _ => throw new NotImplementedException()
            };

            try
            {
                await texthandler;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
            }
        }

        private async ValueTask<Message> CommandForInformationRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, List<string> list)
        {
            var branchNames = (await _branchService.GetBranchesAsync()).Select(x => x.Name).ToList();
            var message = await SendMessage.ForInformationState(botClient, update, cancellationToken, branchNames);
            await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Information);

            return message;
        }

        private async ValueTask<Message> CommandForOptionsRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForOptionsState(botClient, update, cancellationToken);

            return message;
        }

        private async ValueTask<Message> CommandForContactRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForContactState(botClient, update, cancellationToken);

            return message;
        }

        private async ValueTask<Message> CommandForFeedbackRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForGradeState(botClient, update, cancellationToken);
            await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Grade);
            return message;
        }

        private async ValueTask<Message> CommandForChangeLanguageRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForChangeLanguageState(botClient, update, cancellationToken);
            await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.ChangeLanguage);
            return message;
        }

        private async ValueTask<Message> CommandForChangeNumberRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForChangeNumberState(botClient, update, cancellationToken);
            await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.ChangeNumber);
            return message;
        }

        private async ValueTask<Message> CommandForChangeNameRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForChangeNameState(botClient, update, cancellationToken);
            await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.ChangeName);
            return message;
        }

        private async ValueTask<Message> CommandForPreviousRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, Status status)
        {
            Message message;
            if (status == Status.ChangeName || status == Status.ChangeNumber)
            {
                message = await SendMessage.ForOptionsState(botClient,update, cancellationToken);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Active);
                return message;
            }
            else if (status == Status.Information)
            {
                message = await SendMessage.ForMainState(botClient,update, cancellationToken);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Active);
                return message;
            }
            //davomi bo'ladi
            else
            {
                message = await SendMessage.ForMainState(botClient,update, cancellationToken);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Active);
                return message;
            }
        }

        public async ValueTask<Message> CommandForPhoneNumberRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var from = update.Message.From;
            var storageUser = await _clientService.GetClientAsync(update.Message.From.Id);

            if (storageUser == null)
            {
                return await SendMessage.ForPhoneNumberRequest(botClient, update, cancellationToken);
            }
            else
            {
                return await SendMessage.ForMainState(botClient, update, cancellationToken);
            }
        }

        private async ValueTask<Client> Register(ITelegramBotClient botClient, Update update, User? from, CancellationToken cancellationToken)
        {
            var client = new Client()
            {
                TelegramId = from.Id,
                FirstName = from.FirstName,
                LastName = from.LastName,
                Username = from.Username,
            };

            var entry = await _clientService.AddAsync(client);

            return entry;
        }
    }
}
