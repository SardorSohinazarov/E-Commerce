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
            if(storageUser == null)
                storageUser = await Register(botClient, update,from, cancellationToken);

            //authorization:userni stateni topelik
            var state = storageUser.Status;
            if(state == Status.Inactive)
            {
                await SendMessage.ForPhoneNumberRequest(botClient, update, cancellationToken);
                return;
            }
            else if(state == Status.ChangeName)
            {
                if(textMessage != "⬅️ Ortga")
                {
                    await _clientService.UpdateClientNameAsync(from.Id, textMessage);
                }
                else
                {
                    await _clientService.UpdateClientUserStatusAsync(from.Id, Status.Active);
                }
                await SendMessage.ForOptionsState(botClient, update, cancellationToken);
                return;
            }
            else if(state == Status.ChangeNumber)
            {
                if(textMessage != "⬅️ Ortga")
                {
                    await _clientService.UpdateClientPhoneNumberAsync(from.Id, textMessage);
                }
                else
                {
                    await _clientService.UpdateClientUserStatusAsync(from.Id, Status.Active);
                }
                await SendMessage.ForOptionsState(botClient, update, cancellationToken);
                return;
            }
            else if(state == Status.ChangeLanguage)
            {
                var languages = new string[]{ "🇺🇿 O'zbekcha", "🇷🇺 Русский", "🇬🇧 English" };
                if(languages.Contains(textMessage))
                {
                    await _clientService.UpdateClientLanguageCodeAsync(from.Id, textMessage);
                }
                else
                {
                    return;
                }

                await SendMessage.ForOptionsState(botClient, update, cancellationToken);
                return;
            }


            var texthandler = textMessage switch
            {
                "/start" => CommandForPhoneNumberRequest(botClient,update,cancellationToken),
                "⬅️ Ortga" => CommandForPreviousRequest(botClient, update, cancellationToken, state),
                "☎️ Biz bilan aloqa" => SendMessage.ForContactState(botClient, update, cancellationToken),
                "✍️ Fikr bildirish" => SendMessage.ForCommentState(botClient, update, cancellationToken),
                "ℹ️ Ma'lumot" => SendMessage.ForInformationState(botClient, update, cancellationToken, new List<string> { "Kukcha" }),
                "⚙️ Sozlamalar" => SendMessage.ForOptionsState(botClient, update, cancellationToken),
                "🛍 Buyurtma berish" => SendMessage.ForOrdersState(botClient, update, cancellationToken),
                "Ismni o'zgartirish" => CommandForChangeNameRequest(botClient, update, cancellationToken),
                "Raqamni o'zgartirish" => CommandForChangeNumberRequest(botClient, update, cancellationToken),
                "🇺🇿 Tilni tanlang" => CommandForChangeLanguageRequest(botClient, update, cancellationToken),
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
            await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id,Status.ChangeName);
            return message;
        }

        private async ValueTask<Message> CommandForPreviousRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken,Status status)
        {
            if(status == Status.ChangeName)
            {
                var message = await SendMessage.ForOptionsState(botClient,update, cancellationToken);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Options);
                return message;
            }
            //davomi bo'ladi
            else
            {
                var message = await SendMessage.ForMainState(botClient,update, cancellationToken);
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
