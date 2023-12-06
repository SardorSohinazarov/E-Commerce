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
                    var categories = await _categoryService.GetAllCategoryNamessAsync();
                    await SendMessage.ForCategoryState(botClient, update, cancellationToken, categories);
                    await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.PickUpCategory);
                    return;
                }
            }
            else if (state == Status.PickUpCategory)
            {
                var categoryNames = await _categoryService.GetAllCategoryNamessAsync();
                if (categoryNames.Contains(textMessage))
                {
                    var products = await _productService.GetProductNamesByCategoryAsync(textMessage);
                    await SendMessage.ForProductsState(botClient, update, cancellationToken, products);
                    await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.PickUpProducts);
                    return;
                }
            }
            else if (state == Status.PickUpProducts)
            {
                var productNames = (await _productService.GetProductNamesAsync());
                if (productNames.Contains(textMessage))
                {
                    var product = await _productService.GetByNameAsync(textMessage);
                    await _clientService.UpdateClientUserStatusesAsync(from.Id, textMessage, Status.PickUpProductsCount);
                    await SendMessage.ForProductOptions(botClient, update, cancellationToken, product);
                    return;
                }
            }
            else if (state == Status.PickUpProductsCount && "123456789".Contains(textMessage))
            {
                var product = await _productService.GetByNameAsync(storageUser.LastBasketProduct);

                ProductList productList = new ProductList()
                {
                    UserTelegramId = from.Id,
                    Count = int.Parse(textMessage),
                    ProductId = product.Id,
                };

                var basket = await _basketService.GetBasketAsync(from.Id);
                var products = basket.Products.Select(x => x.Product);
                var productNames = products.Select(x => x.Name);

                //yo'q bo'lsa qo'shadi endi
                if(!productNames.Contains(storageUser.LastBasketProduct)) 
                {
                    await _basketService.UpdateBasketProductsAsync(product, int.Parse(textMessage), from.Id);
                }

                await _clientService.UpdateClientUserStatusesAsync(from.Id, "", Status.PickUpCategory);
                var categories = await _categoryService.GetAllCategoryNamessAsync();
                await SendMessage.ForCategoryState(botClient, update, cancellationToken, categories);
            }
            else if (state == Status.Basket)
            {
                var productNames = (await _productService.GetProductNamesAsync());

                foreach(var product in productNames)
                {
                    if("❌"+product == textMessage)
                    {
                        await _basketService.DeleteProductFromName(product, from.Id);
                        return;
                    }
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
                "🚖 Yetkazib berish" => CommandForDeliveryState(botClient, update, cancellationToken),
                "🏃 Olib ketish" => CommandForPickUpState(botClient, update, cancellationToken),
                "📥 Savat" => CommandForBasketRequest(botClient, update, cancellationToken),
                "🚖 Buyurtuma berish" => CommandForMainCommand(botClient, update, cancellationToken),
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

        private async ValueTask<Message> CommandForMainCommand(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketAsync(update.Message.From.Id);

            var order = new Order()
            {
                ProductList = basket.Products
            };

            order = await _orderService.AddOrderAsync(order);

            var message = await SendMessage.ForOrderedProductsState(botClient, update, cancellationToken, order);

            return message;
        }

        private async ValueTask<Message> CommandForBasketRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketAsync(update.Message.From.Id);
            var productList = basket.Products.Select(x => new Tuple<int, Product>((int)x.Count, x.Product)).ToList();
            await _clientService.UpdateClientUserStatusesAsync(update.Message.From.Id, "", Status.Basket);
            var message = await SendMessage.ForBasketState(botClient, update, cancellationToken, productList);

            return message;
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
            else if (status == Status.PickUpProductsCount)
            {
                var products = await _productService.GetProductNamesAsync();
                message = await SendMessage.ForProductsState(botClient, update, cancellationToken, products);
                await _clientService.UpdateClientUserStatusesAsync(update.Message.From.Id, "", Status.PickUpProducts);

                return message;
            }
            else if (status == Status.Basket)
            {
                var categories = await _categoryService.GetAllCategoryNamessAsync();
                message = await SendMessage.ForCategoryState(botClient, update, cancellationToken, categories);
                await _clientService.UpdateClientUserStatusesAsync(update.Message.From.Id, "", Status.PickUpCategory);

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
