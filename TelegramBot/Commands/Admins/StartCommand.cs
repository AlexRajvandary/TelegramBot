using Telegram.Bot;

namespace TelegramBot.Commands.Admins
{
    public class StartCommand : ICommand
    {
        public string Name => "/start";

        public Task Execute(long chatId, ITelegramBotClient botClient)
        {
            throw new NotImplementedException();
        }
    }
}
