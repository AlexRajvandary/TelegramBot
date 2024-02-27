using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Commands.Users
{
    public class StartCommand : ICommand
    {
        public string Name => "/start";


        public async Task Execute(long chatId, ITelegramBotClient botClient)
        {
            var keyboard = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithWebApp("Перейти в каталог", new WebAppInfo(){Url = "https://master--bespoke-rugelach-7b0f4e.netlify.app/"})
                    },
                     new []
                    {
                        InlineKeyboardButton.WithCallbackData("Меню", "/menu")
                    },
                      new []
                    {
                        InlineKeyboardButton.WithCallbackData("Действующие подписки", "/currentSubscriptions")
                    },
                       new []
                    {
                        InlineKeyboardButton.WithCallbackData("История", "/history")
                    },
                        new []
                    {
                        InlineKeyboardButton.WithCallbackData("В ожидании", "/orders")
                    }
            });

            var text = "Добро пожаловать в магазин иностранных подписок! Здесь вы можете приобрести подписки на иностранные сервисы.";

            await botClient.SendTextMessageAsync(chatId,
                                                 text,
                                                 replyMarkup: keyboard);
        }
    }
}
