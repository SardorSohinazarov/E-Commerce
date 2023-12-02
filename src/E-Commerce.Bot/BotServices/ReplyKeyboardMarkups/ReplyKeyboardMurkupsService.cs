using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;

namespace E_Commerce.Bot.BotServices.ReplyKeyboardMarkups
{
    public class ReplyKeyboardMurkupsService
    {
        public static async ValueTask<Message> SendMurkupWithPhoneNumberRequest(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            var keyboardButton = KeyboardButton.WithRequestContact("📱 Share phone number 📱");
            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButton);

            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "📱 Telefon raqamingiz qanday? Telefon raqamingizni jo'natish uchun, quyidagi \"📱 Raqamni jo'natish\" tugmasini bosing.",
                    parseMode: ParseMode.Html,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> SendMurkupForMainState(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>{
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🛍 Buyurtma berish"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("✍️ Fikr bildirish"),
                    new KeyboardButton("☎️ Biz bilan aloqa"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("ℹ️ Ma'lumot"),
                    new KeyboardButton("⚙️ Sozlamalar"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Juda yaxshi birgalikda buyurtma beramizmi? 😃",
                    parseMode: ParseMode.Html,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> SendMurkupForContactState(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>{
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🛍 Buyurtma berish"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("✍️ Fikr bildirish"),
                    new KeyboardButton("☎️ Biz bilan aloqa"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("ℹ️ Ma'lumot"),
                    new KeyboardButton("⚙️ Sozlamalar"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Agar sizda savollar bo'lsa bizga telefon qilishingiz mumkin: +998 95-115-44-30",
                    parseMode: ParseMode.Html,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> SendMurkupForCommentState(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>{
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Hammasi yoqdi ♥️"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Yaxshi ⭐️⭐️⭐️⭐️"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Yoqmadi ⭐️⭐️⭐️"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Yomon ⭐️⭐️"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Juda yomon 👎🏻"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("⬅️ Ortga"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Fish and Breadni tanlaganingiz uchun rahmat.\r\nAgar siz bizning xizmat sifatimizni yaxshilashimizga yordam bersangiz hursand bulardik.\r\nBuning uchun 5 bal tizim asosida baholang",
                    parseMode: ParseMode.Html,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                );

            return message;
        }

        public static async ValueTask<Message> SendMurkupForInformationState(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken, List<string> filials)
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>();
            
            foreach(var filial in filials)
            {
                keyboardButtons.Add(new List<KeyboardButton>()
                {
                    new KeyboardButton(filial),
                });
            };

            keyboardButtons.Add(new List<KeyboardButton>()
                {
                    new KeyboardButton("⬅️ Ortga"),
                });

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Qaysi shahobchani tanlaysiz?",
                    parseMode: ParseMode.Html,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                );

            return message;
        }
        
        public static async ValueTask<Message> SendMurkupForOptionsState(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>()
            {
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Ismni o'zgartirish"),
                    new KeyboardButton("Raqamni o'zgartirish"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🇺🇿 Tilni tanlang"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("⬅️ Ortga"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "⚙️ Sozlamalar",
                    parseMode: ParseMode.Html,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                );

            return message;
        }
        
        public static async ValueTask<Message> SendMurkupForOrdersState(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>()
            {
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🚖 Yetkazib berish"),
                    new KeyboardButton("🏃 Olib ketish"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("⬅️ Ortga"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            var message = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "⚙️ Sozlamalar",
                    parseMode: ParseMode.Html,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                );

            return message;
        }
    }
}
