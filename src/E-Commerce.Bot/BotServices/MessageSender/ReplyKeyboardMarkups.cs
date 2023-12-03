using Telegram.Bot.Types.ReplyMarkups;

namespace E_Commerce.Bot.BotServices.MessageSender
{
    public class ReplyKeyboardMarkups
    {
        public static async ValueTask<ReplyKeyboardMarkup> ForPhoneNumberRequest()
        {
            var keyboardButton = KeyboardButton.WithRequestContact("📱 Share phone number 📱");
            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButton);

            return replyKeyboardMarkup;
        }

        public static async ValueTask<ReplyKeyboardMarkup> ForMainState()
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>{
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🛍 Buyurtma berish"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("✍️ Fikr bildirish"),
                    new KeyboardButton("☎️ Biz bilan aloqa"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("ℹ️ Ma'lumot"),
                    new KeyboardButton("⚙️ Sozlamalar"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }

        public static async ValueTask<ReplyKeyboardMarkup> ForContactState()
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>{
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🛍 Buyurtma berish"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("✍️ Fikr bildirish"),
                    new KeyboardButton("☎️ Biz bilan aloqa"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("ℹ️ Ma'lumot"),
                    new KeyboardButton("⚙️ Sozlamalar"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }

        public static async ValueTask<ReplyKeyboardMarkup> ForFeedbackGradeState()
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>{
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Hammasi yoqdi ♥️"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Yaxshi ⭐️⭐️⭐️⭐️"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Yoqmadi ⭐️⭐️⭐️"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Yomon ⭐️⭐️"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Juda yomon 👎🏻"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("⬅️ Ortga"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }

        public static async ValueTask<ReplyKeyboardMarkup> ForInformationState(List<string> filials)
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>();

            foreach (var filial in filials)
            {
                keyboardButtons.Add(new List<KeyboardButton>()
                {
                    new KeyboardButton(filial),
                });
            };

            keyboardButtons.Add(new List<KeyboardButton>()
                {
                    new KeyboardButton("⬅️ Ortga"),
                });

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }

        public static async ValueTask<ReplyKeyboardMarkup> ForOptionsState()
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>()
            {
                new List<KeyboardButton>()
                {
                    new KeyboardButton("Ismni o'zgartirish"),
                    new KeyboardButton("Raqamni o'zgartirish"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🇺🇿 Tilni tanlang"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("⬅️ Ortga"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }

        public static async ValueTask<ReplyKeyboardMarkup> ForOrdersState()
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>()
            {
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🚖 Yetkazib berish"),
                    new KeyboardButton("🏃 Olib ketish"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("⬅️ Ortga"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }

        public static async ValueTask<ReplyKeyboardMarkup> ForChangeNameState()
        {
            var keyboardButton = new KeyboardButton("⬅️ Ortga");
            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButton);

            return replyKeyboardMarkup;
        }

        public static async ValueTask<ReplyKeyboardMarkup> ForChangeNumberState()
        {
            var keyboardButton = new KeyboardButton("⬅️ Ortga");
            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButton);

            return replyKeyboardMarkup;
        }

        public static async ValueTask<ReplyKeyboardMarkup> ForChangeLanguageState()
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>{
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🇺🇿 O'zbekcha"),
                    new KeyboardButton("🇷🇺 Русский"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🇬🇧 English"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }
    }
}
