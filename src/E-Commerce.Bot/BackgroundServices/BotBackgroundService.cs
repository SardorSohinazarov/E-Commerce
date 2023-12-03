using Telegram.Bot;
using Telegram.Bot.Polling;

namespace E_Commerce.Bot.BackgroundServices
{
    public class BotBackgroundService : BackgroundService
    {
        private readonly ILogger<BotBackgroundService> _logger;
        private readonly TelegramBotClient _botClient;
        private readonly IUpdateHandler _updateHandler;

        public BotBackgroundService(
            ILogger<BotBackgroundService> logger,
            TelegramBotClient botClient,
            IUpdateHandler updateHandler)
        {
            _logger = logger;
            _botClient = botClient;
            _updateHandler = updateHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var bot = await _botClient.GetMeAsync(stoppingToken);

            _logger.LogInformation("Telegram bot :{bot.Username} is started listening", bot.Username);

            _botClient.StartReceiving(
                updateHandler: _updateHandler.HandleUpdateAsync,
                pollingErrorHandler: _updateHandler.HandlePollingErrorAsync,
                receiverOptions: new ReceiverOptions()
                {
                    ThrowPendingUpdates = true
                },
                cancellationToken: stoppingToken
                );
        }
    }
}
