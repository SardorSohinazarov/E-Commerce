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
