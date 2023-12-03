using E_Commerce.Bot.BotServices.MessageSender;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace E_Commerce.Bot.BotServices
{
    public partial class UpdateHandlerService
    {
        private async Task HandleTextMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var storageUser = await _clientService.GetClientAsync(update.Message.From.Id);
            if(storageUser == null)
            {

            }

            var textMessage = update.Message.Text;

            var texthandler = textMessage switch
            {
                "/start" => CommandForPhoneNumberRequest(botClient,update,cancellationToken),
                "⬅️ Ortga" => SendMessage.ForMainState(botClient, update, cancellationToken),
                "☎️ Biz bilan aloqa" => SendMessage.ForContactState(botClient, update, cancellationToken),
                "✍️ Fikr bildirish" => SendMessage.ForCommentState(botClient, update, cancellationToken),
                "ℹ️ Ma'lumot" => SendMessage.ForInformationState(botClient, update, cancellationToken, new List<string> { "Kukcha" }),
                "⚙️ Sozlamalar" => SendMessage.ForOptionsState(botClient, update, cancellationToken),
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

        public async ValueTask<Message> CommandForPhoneNumberRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            return await SendMessage.ForPhoneNumberRequest(botClient, update, cancellationToken);
        }
    }
}
