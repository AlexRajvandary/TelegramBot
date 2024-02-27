using Telegram.Bot;

namespace TelegramBot.Commands.Users
{
    public class OrdersCommand : ICommand
    {
        public string Name => "/orders";

        public Task Execute(long chatId, ITelegramBotClient botClient)
        {
            throw new NotImplementedException();
        }
    }
}
