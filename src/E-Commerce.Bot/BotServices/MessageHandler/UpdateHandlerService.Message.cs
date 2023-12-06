using E_Commerce.Bot.BotServices.MessageSender;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Enums;
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

        private async Task HandleLocationAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var from = update.Message.From;
            var location = update.Message.Location;

            var client = await _clientService.GetClientAsync(from.Id);
            if (client == null)
                throw new Exception("Client not found");

            var branch = await NearFilialLocationAsync(location.Latitude, location.Longitude);

            if (client.Status == Status.Delivery)
            {
                client = await _clientService.UpdateClientUserStatusAsync(from.Id, Status.DeliveryCategory);
            }
            else if (client.Status == Status.PickUp)
            {
                client = await _clientService.UpdateClientUserStatusAsync(from.Id, Status.PickUpCategory);

                await SendMessage.ForBranchState(botClient, update, cancellationToken, branch);
            }

            //davomi bo'lishi mumkin
        }

        private async ValueTask<Branch> NearFilialLocationAsync(double lat, double lon)
        {
            var branches = await _branchService.GetBranchesAsync();
            double min = double.MaxValue;

            Branch branch = new Branch();
            for (int i = 0; i < branches.Count; i++)
            {
                if (Math.Sqrt(Math.Pow((double)(branches[i].Latitude - lat), 2) + Math.Pow((double)(branches[i].Longitude - lon), 2)) < min)
                {
                    branch = branches[i];
                    min = Math.Sqrt(Math.Pow((double)(branches[i].Latitude - lat), 2) + Math.Pow((double)(branches[i].Longitude - lon), 2));
                }
            }
            return branch;
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
    }
}
