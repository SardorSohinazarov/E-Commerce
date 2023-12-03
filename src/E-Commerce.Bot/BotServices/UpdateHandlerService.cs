using E_Commerce.Application.Services.Branches;
using E_Commerce.Application.Services.Clients;
using E_Commerce.Application.Services.Feedbacks;
using E_Commerce.Application.Services.Rates;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace E_Commerce.Bot.BotServices
{
    public partial class UpdateHandlerService : IUpdateHandler
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private IClientService _clientService;
        private IFeedbackService _feedbackService;
        private IRateService _rateService;
        private IBranchService _branchService;

        public UpdateHandlerService(IServiceScopeFactory scopeFactory)
            => _scopeFactory = scopeFactory;

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateAsyncScope();
            _clientService = scope.ServiceProvider.GetService<IClientService>();
            _feedbackService = scope.ServiceProvider.GetService<IFeedbackService>();
            _rateService = scope.ServiceProvider.GetService<IRateService>();
            _branchService = scope.ServiceProvider.GetService<IBranchService>();

            var updateHandler = update.Type switch
            {
                UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken),
                UpdateType.EditedMessage => HandleEditedMessageAsync(botClient, update, cancellationToken),
                UpdateType.CallbackQuery => HandleCallbackQueryAsync(botClient, update, cancellationToken),
                UpdateType.InlineQuery => HandleInlineQueryAsync(botClient, update, cancellationToken),
                _ => HandleUnknownUpdateAsync(botClient, update, cancellationToken),
            };

            try
            {
                await updateHandler;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Task HandleInlineQueryAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleCallbackQueryAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleEditedMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleUnknownUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
