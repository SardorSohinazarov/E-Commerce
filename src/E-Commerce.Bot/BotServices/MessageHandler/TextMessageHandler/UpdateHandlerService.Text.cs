using E_Commerce.Bot.BotServices.MessageSender;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace E_Commerce.Bot.BotServices
{
    public partial class UpdateHandlerService
    {
        private async Task HandleTextMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var textMessage = update.Message.Text;

            if(textMessage == "/start") 
                 await SendMessage.ForPhoneNumberRequest(botClient, update, cancellationToken);

            if(textMessage == "⬅️ Ortga")
                await SendMessage.ForMainState(botClient, update, cancellationToken);

            if(textMessage == "☎️ Biz bilan aloqa")
                await SendMessage.ForContactState(botClient, update, cancellationToken);

            if(textMessage == "✍️ Fikr bildirish")
                await SendMessage.ForCommentState(botClient, update, cancellationToken);

            if (textMessage == "ℹ️ Ma'lumot")
                await SendMessage.ForInformationState(botClient, update, cancellationToken, new List<string> { "Kukcha" });
            
            if (textMessage == "⚙️ Sozlamalar")
                await SendMessage.ForOptionsState(botClient, update, cancellationToken);

            if(textMessage == "🛍 Buyurtma berish")
                await SendMessage.ForOrdersState(botClient, update, cancellationToken);
        }
    }
}
