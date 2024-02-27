using Telegram.Bot;

namespace TelegramBot.Commands.Users
{
    public class HistoryCommand : ICommand
    {
        public string Name => "/history";

        public Task Execute(long chatId, ITelegramBotClient botClient)
        {
            throw new NotImplementedException();
        }
    }
}
