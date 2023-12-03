using E_Commerce.Bot.BotServices.MessageSender;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace E_Commerce.Bot.BotServices
{
    public partial class UpdateHandlerService
    {
        private async Task<Client?> Authentication(ITelegramBotClient botClient, Update update, User? from, Client? storageUser, CancellationToken cancellationToken)
        {
            if (storageUser == null)
                storageUser = await Register(botClient, update, from, cancellationToken);

            return storageUser;
        }

        private async ValueTask<Message> CommandForInformationRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var branchNames = (await _branchService.GetBranchesAsync()).Select(x => x.Name).ToList();
            var message = await SendMessage.ForInformationState(botClient, update, cancellationToken, branchNames);
            await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Information);

            return message;
        }

        private async ValueTask<Message> CommandForOptionsRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForOptionsState(botClient, update, cancellationToken);

            return message;
        }

        private async ValueTask<Message> CommandForContactRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForContactState(botClient, update, cancellationToken);

            return message;
        }

        private async ValueTask<Message> CommandForFeedbackRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForGradeState(botClient, update, cancellationToken);
            await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Grade);

            return message;
        }

        private async ValueTask<Message> CommandForChangeLanguageRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForChangeLanguageState(botClient, update, cancellationToken);
            await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.ChangeLanguage);

            return message;
        }

        private async ValueTask<Message> CommandForChangeNumberRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForChangeNumberState(botClient, update, cancellationToken);
            await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.ChangeNumber);

            return message;
        }

        private async ValueTask<Message> CommandForChangeNameRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = await SendMessage.ForChangeNameState(botClient, update, cancellationToken);
            await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.ChangeName);

            return message;
        }

        private async ValueTask<Message> CommandForPreviousRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, Status status)
        {
            Message message;
            if (status == Status.ChangeName || status == Status.ChangeNumber)
            {
                message = await SendMessage.ForOptionsState(botClient, update, cancellationToken);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Active);

                return message;
            }
            else if (status == Status.Information)
            {
                message = await SendMessage.ForMainState(botClient, update, cancellationToken);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Active);

                return message;
            }
            //to be continued
            else
            {
                message = await SendMessage.ForMainState(botClient, update, cancellationToken);
                await _clientService.UpdateClientUserStatusAsync(update.Message.From.Id, Status.Active);

                return message;
            }
        }

        public async ValueTask<Message> CommandForPhoneNumberRequest(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var from = update.Message.From;
            var storageUser = await _clientService.GetClientAsync(update.Message.From.Id);

            if (storageUser == null)
                return await SendMessage.ForPhoneNumberRequest(botClient, update, cancellationToken);
            else
                return await SendMessage.ForMainState(botClient, update, cancellationToken);
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
