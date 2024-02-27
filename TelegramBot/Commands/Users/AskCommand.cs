using Telegram.Bot;

namespace TelegramBot.Commands.Users
{
    public class AskCommand : ICommand
    {
        public string Name => "/ask";

        public Task Execute(long chatId, ITelegramBotClient botClient)
        {
            throw new NotImplementedException();
        }
    }
}
