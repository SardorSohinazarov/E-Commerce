using E_Commerce.Bot.BotServices.ReplyKeyboardMarkups;
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
                 await ReplyKeyboardMurkupsService.SendMurkupWithPhoneNumberRequest(botClient, update, cancellationToken);

            if(textMessage == "⬅️ Ortga")
                await ReplyKeyboardMurkupsService.SendMurkupForMainState(botClient, update, cancellationToken);

            if(textMessage == "☎️ Biz bilan aloqa")
                await ReplyKeyboardMurkupsService.SendMurkupForContactState(botClient,update, cancellationToken);

            if(textMessage == "✍️ Fikr bildirish")
                await ReplyKeyboardMurkupsService.SendMurkupForCommentState(botClient,update, cancellationToken);

            if (textMessage == "ℹ️ Ma'lumot")
                await ReplyKeyboardMurkupsService.SendMurkupForInformationState(botClient, update, cancellationToken, new List<string> { "Kukcha" });
            
            if (textMessage == "⚙️ Sozlamalar")
                await ReplyKeyboardMurkupsService.SendMurkupForOptionsState(botClient, update, cancellationToken);

            if(textMessage == "🛍 Buyurtma berish")
                await ReplyKeyboardMurkupsService.SendMurkupForOrdersState(botClient, update, cancellationToken);
        }
    }
}
