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
            else if (state == Status.PickUp)
            {
                var filialNames = (await _branchService.GetBranchesAsync()).Select(x => x.Name);
                if (filialNames.Contains(textMessage))
                {
                    var categories = (await _categoryService.GetAllCategoriesAsync()).Select(x => x.Name).ToList();
                    await SendMessage.ForCategoryState(botClient, update, cancellationToken,categories);
                    await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.PickUpCategory);
                    return;
                }
            }
            else if (state == Status.PickUpCategory)
            {
                var categoryNames = (await _categoryService.GetAllCategoriesAsync()).Select(x => x.Name);
                if (categoryNames.Contains(textMessage))
                {
                    var products = await _productService.GetProductNamesByCategoryAsync(textMessage);
                    await SendMessage.ForProductsState(botClient, update, cancellationToken, products);
                    await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.PickUpProducts);
                    return;
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
                "🚖 Yetkazib berish" => CommandForDeliveryState(botClient,update,cancellationToken),
                //refactor qilinmaganlari
                "🛍 Buyurtma berish" => SendMessage.ForOrdersState(botClient, update, cancellationToken),
                "🏃 Olib ketish" => CommandForPickUpState(botClient, update, cancellationToken),
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

        private async ValueTask<Message> CommandForPreviousRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, Status status)
        {
            Message message;
            if (status == Status.ChangeName || status == Status.ChangeNumber)
            {
                message = await SendMessage.ForOptionsState(botClient, update, cancellationToken);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Active);

                return message;
            }
            else if (status == Status.Information)
            {
                message = await SendMessage.ForMainState(botClient, update, cancellationToken);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Active);

                return message;
            }
            else if (status == Status.Delivery || status == Status.PickUp)
            {
                message = await SendMessage.ForOrdersState(botClient, update, cancellationToken);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Active);

                return message;
            }
            else if (status == Status.PickUpCategory)
            {
                var filialNames = (await _branchService.GetBranchesAsync()).Select(x => x.Name).ToList();
                message = await SendMessage.ForPickUpState(botClient, update, cancellationToken, filialNames);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.PickUp);

                return message;
            }
            else if (status == Status.PickUpProducts)
            {
                var categoryNames = (await _categoryService.GetAllCategoriesAsync()).Select(x => x.Name).ToList();
                message = await SendMessage.ForCategoryState(botClient, update, cancellationToken, categoryNames);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.PickUpCategory);

                return message;
            }
            //to be continued
            else
            {
                message = await SendMessage.ForMainState(botClient, update, cancellationToken);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Active);

                return message;
            }
        }
    }
}
