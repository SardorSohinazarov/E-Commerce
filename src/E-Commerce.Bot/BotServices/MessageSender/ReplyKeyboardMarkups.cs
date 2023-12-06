using E_Commerce.Domain.Entities;
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

        internal static async Task<IReplyMarkup?> ForLocationRequest()
        {
            var keyboardButtons = new List<List<KeyboardButton>>()
            {
                new List<KeyboardButton>
                {
                    KeyboardButton.WithRequestLocation("Eng yaqin filialni aniqlash"),
                }, 
                new List<KeyboardButton>()
                {
                    new KeyboardButton("⬅️ Ortga")
                }
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }

        internal static async Task<ReplyKeyboardMarkup> ForPickUpState(List<string> filials)
        {
            var keyboardButtons = new List<List<KeyboardButton>>()
            {
                new List<KeyboardButton>
                {
                    KeyboardButton.WithRequestLocation("Eng yaqin filialni aniqlash"),
                },
            };

            var filialsCount = filials.Count;

            var rowCount = filialsCount / 2;

            for (int i = 0; i < rowCount; i=+2)
            {
                keyboardButtons.Add(
                    new List<KeyboardButton>
                    {
                        new KeyboardButton(filials[i]),
                        new KeyboardButton(filials[i+1]),
                    });
            }

            if(filialsCount % 2 == 1) 
            {
                keyboardButtons.Add(
                    new List<KeyboardButton>
                    {
                        new KeyboardButton(filials[filialsCount - 1]),
                    });
            }

            keyboardButtons.Add(new List<KeyboardButton>()
                {
                    new KeyboardButton("⬅️ Ortga")
                });

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }

        public static async Task<IReplyMarkup?> ForCategoryState(List<string> categories)
        {
            var categoryCount = categories.Count;
            var rowCount = categoryCount / 2;

            var keyboardButtons = new List<List<KeyboardButton>>()
            {
                new List<KeyboardButton>
                {
                    new KeyboardButton("⬅️ Ortga"),
                },
            };

            for (int i = 0; i < rowCount; i+=2)
            {
                keyboardButtons.Add(
                   new List<KeyboardButton>
                   {
                        new KeyboardButton(categories[i]),
                        new KeyboardButton(categories[i+1]),
                   });
            }

            if (categoryCount % 2 == 1)
            {
                keyboardButtons.Add(
                    new List<KeyboardButton>
                    {
                        new KeyboardButton(categories[categoryCount - 1]),
                    });
            }

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }

        public static async Task<IReplyMarkup?> ForProductsState(List<string> products)
        {
            var productsCount = products.Count;
            var rowCount = productsCount / 2;

            var keyboardButtons = new List<List<KeyboardButton>>()
            {
                new List<KeyboardButton>
                {
                    new KeyboardButton("⬅️ Ortga"),
                },
            };

            for (int i = 0; i < rowCount; i += 2)
            {
                keyboardButtons.Add(
                   new List<KeyboardButton>
                   {
                        new KeyboardButton(products[i]),
                        new KeyboardButton(products[i+1]),
                   });
            }

            if (productsCount % 2 == 1)
            {
                keyboardButtons.Add(
                    new List<KeyboardButton>
                    {
                        new KeyboardButton(products[productsCount - 1]),
                    });
            }

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }
    }
}
