using E_Commerce.Application.DTOs;
using E_Commerce.Bot.BotServices.MessageSender;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Enums;
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
            storageUser = await Authentication(botClient, update, from, storageUser, cancellationToken);

            //authorization:userni stateni topelik
            #region Status Checker
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
            else if (state == Status.Information)
            {
                if (textMessage != "⬅️ Ortga")
                {
                    var branch = await _branchService.GetBranchFromNameAsync(textMessage);
                    if (branch == null)
                    {
                        await SendMessage.InformationNotFound(botClient, update, cancellationToken);
                        return;
                    }

                    await SendMessage.ForBranchState(botClient, update, cancellationToken, branch);
                }
            }
            #endregion


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
                "ℹ️ Ma'lumot" => CommandForInformationRequest(botClient, update, cancellationToken),
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
    }
}
