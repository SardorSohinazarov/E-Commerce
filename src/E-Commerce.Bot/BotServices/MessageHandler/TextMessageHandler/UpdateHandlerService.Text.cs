using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace E_Commerce.Bot.BotServices
{
    public partial class UpdateHandlerService
    {
        private async Task HandleTextMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var textMessage = update.Message.Text;

            if(textMessage == "/start") 
            {
                var keyboardButton = KeyboardButton.WithRequestContact("📱 Share phone number 📱");
                
                ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButton);


                await botClient.SendTextMessageAsync(
                    chatId:update.Message.Chat.Id,
                    text: "📱 Telefon raqamingiz qanday? Telefon raqamingizni jo'natish uchun, quyidagi \"📱 Raqamni jo'natish\" tugmasini bosing.",
                    parseMode:ParseMode.Html,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken:cancellationToken
                );
            }
        }
    }
}
