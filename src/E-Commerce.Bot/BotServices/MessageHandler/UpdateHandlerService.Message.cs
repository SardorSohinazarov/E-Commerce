using E_Commerce.Bot.BotServices.MessageSender;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace E_Commerce.Bot.BotServices
{
    public partial class UpdateHandlerService
    {
        private async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var messageHandler = update.Message.Type switch
            {
                MessageType.Text => HandleTextMessageAsync(botClient, update, cancellationToken),
                MessageType.Location => HandleLocationAsync(botClient, update, cancellationToken),
                MessageType.Contact => HandleContactAsync(botClient, update, cancellationToken),
                MessageType.Audio => HandleAudioAsync(botClient, update, cancellationToken),
                MessageType.Sticker => HandlerStrikerAsync(botClient, update, cancellationToken),
                MessageType.Photo => HandlePhotoAsync(botClient, update, cancellationToken),
                MessageType.Dice => HandleDiceAsync(botClient, update, cancellationToken),
                MessageType.Document => HandleDocumentAsync(botClient, update, cancellationToken),
                MessageType.Game => HandleGameAsync(botClient, update, cancellationToken),
                MessageType.Invoice => HandleInvoiceAsync(botClient, update, cancellationToken),
                MessageType.Poll => HandlePollAsync(botClient, update, cancellationToken),
                MessageType.Voice => HandleVoiceAsync(botClient, update, cancellationToken),
                MessageType.VideoNote => HandleVideoNote(botClient, update, cancellationToken),
                MessageType.WebAppData => HandleWebAppDataAsync(botClient, update, cancellationToken),
                MessageType.Video => HandleVideoAsync(botClient, update, cancellationToken),
                _ => HandleUnknownMessageAsync(botClient, update, cancellationToken)
            };

            try
            {
                await messageHandler;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private async Task HandleContactAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var from = update.Message.From;
            var contact = update.Message.Contact;

            var client = await _clientService.UpdateClientPhoneNumberAsync(from.Id, contact.PhoneNumber);

            Console.WriteLine($"Telefon no'mer keldiyu {update.Message.Contact.PhoneNumber}");

            await SendMessage.ForMainState(botClient, update, cancellationToken);
        }

        private async Task HandleUnknownMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            => Console.WriteLine("Bizga kutilmagan typedagi xabar keldi");

        private Task HandleVideoAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleWebAppDataAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleVideoNote(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleVoiceAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandlePollAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleInvoiceAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleGameAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleDocumentAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleDiceAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandlePhotoAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandlerStrikerAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleAudioAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Task HandleLocationAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
