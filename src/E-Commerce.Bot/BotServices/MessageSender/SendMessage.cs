using E_Commerce.Domain.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace E_Commerce.Bot.BotServices.MessageSender
{
    public class SendMessage
    {
        public static async ValueTask<Message> ForPhoneNumberRequest(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "📱 Telefon raqamingiz qanday? Telefon raqamingizni jo'natish uchun, quyidagi \"📱 Raqamni jo'natish\" tugmasini bosing.",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForPhoneNumberRequest(),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> ForMainState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Juda yaxshi birgalikda buyurtma beramizmi? 😃",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForMainState(),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> ForContactState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Agar sizda savollar bo'lsa bizga telefon qilishingiz mumkin: +998 95-115-44-30",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForContactState(),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> ForGradeState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Fish and Breadni tanlaganingiz uchun rahmat.\r\nAgar siz bizning xizmat sifatimizni yaxshilashimizga yordam bersangiz hursand bulardik.\r\nBuning uchun 5 bal tizim asosida baholang",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForFeedbackGradeState(),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> ForFeedbackState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "O'z fikr va mulohazalaringizni jo'nating.",
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> ForInformationState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken,
            List<string> filials)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Qaysi shahobchani tanlaysiz?",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForInformationState(filials),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> ForOptionsState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "⚙️ Sozlamalar",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForOptionsState(),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> ForOrdersState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Okay, pick up or delivery?",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForOrdersState(),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> ForChangeNameState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Ismingizni kiriting",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForChangeNameState(),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> ForChangeNumberState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "📱 Raqamni +998 ** *** ** ** shakilda yuboring.",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForChangeNumberState(),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> ForChangeLanguageState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "🇺🇿 Tilni tanlang",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForChangeLanguageState(),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> ForBranchState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken,
            Branch branch)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: branch.Description ?? "Ma'lumot yo'q",
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken
                );

            await botClient.SendLocationAsync(
                    chatId: update.Message.Chat.Id,
                    latitude: branch.Latitude ?? 0,
                    longitude: branch.Longitude ?? 0,
                    cancellationToken: cancellationToken
                );

            return message;
        }

        internal static async ValueTask<Message> InformationNotFound(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Malumot topilmadi",
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken
                );

            return message;
        }

        internal static async ValueTask<Message> ForDeliveryState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Buyurtmangizni qayerga yetkazib berish kerak 🚙?",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForLocationRequest(),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        internal static async ValueTask<Message> ForPickUpState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken,
            List<string> filials)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Siz qayerda joylashgansiz 👀?\r\nAgar lokatsiyangizni jo'natsangiz 📍, sizga yaqin bo'lgan filialni aniqlaymiz",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForPickUpState(filials),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        internal static async ValueTask<Message> ForCategoryState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken,
            List<string> categories)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Categories",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForCategoryState(categories),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        internal static async ValueTask<Message> ForProductsState(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken,
            List<string> products)
        {
            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Products",
                    parseMode: ParseMode.Html,
                    replyMarkup: await ReplyKeyboardMarkups.ForProductsState(products),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        internal static async ValueTask<Message> ForProductOptions(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken,
            Product product)
        {
            var message = await botClient.SendPhotoAsync(
                    chatId: update.Message.Chat.Id,
                    photo: new InputOnlineFile(product.ImagePath),
                    //product.ImagePath,
                    caption: $"{product.Name}\n Narxi: {product.Price} so'm",
                    replyMarkup: await ReplyKeyboardMarkups.ForProductsCountState(),
                    parseMode: ParseMode.Markdown,
                    cancellationToken: cancellationToken
                );

            return message;
        }

        internal static async ValueTask<Message> ForBasketState(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, List<Tuple<int,Product>> productLists)
        {
            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                    text: "*«❌ Maxsulot nomi»* - savatdan o'chirish \r\n *«🔄 Tozalash»* - savatni butunlay bo'shatish",
                    parseMode: ParseMode.Markdown,
                    cancellationToken: cancellationToken
                );

            string text = "📥 Savat:\r\n\r\n";

            decimal jami = 0;
            foreach( var item in productLists )
            {
                var summa = item.Item2.Price * item.Item1;
                text = text + item.Item2.Name + "\n";
                text = text + $"{item.Item2.Price} x {item.Item1} = {summa}\n\n";
                jami = jami + summa;
            }

            text = text + $"\nJami: {jami} so'm";

            var message = await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                    text: text,
                    parseMode: ParseMode.Markdown,
                    replyMarkup: await ReplyKeyboardMarkups.ForBasketState(productLists),
                    cancellationToken: cancellationToken
                );

            return message;
        }

        internal static async ValueTask<Message> ForOrderedProductsState(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken, Order order)
        {
            string text = "🗒 Chek:\r\n\r\n";

            decimal jami = 0;
            foreach (var product in order.ProductList)
            {
                var summa = product.Product.Price * product.Count;
                text = text + product.Product.Name + "\n";
                text = text + $"{product.Product.Price} x {product.Count} = {summa}\n\n";
                jami = jami + (decimal)summa;
            }

            text = text + $"\nJami: {jami} so'm";

            var message = await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                    text: text,
                    parseMode: ParseMode.Markdown,
                    cancellationToken: cancellationToken
                );

            return message;
        }
    }
}
