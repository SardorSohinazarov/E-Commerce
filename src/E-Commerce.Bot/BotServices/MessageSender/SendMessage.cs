using E_Commerce.Domain.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

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
                    text: "⚙️ Sozlamalar",
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
    }
}
