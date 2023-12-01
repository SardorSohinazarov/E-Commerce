using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace E_Commerce.Bot.BotServices
{
    public class UpdateHandlerService : IUpdateHandler
    {
        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: update.Message.Text,
                parseMode: ParseMode.Html,
                replyToMessageId: update.Message.MessageId,
                cancellationToken:cancellationToken
                );
        }
    }
}
