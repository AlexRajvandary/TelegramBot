using Telegram.Bot;

namespace TelegramBot.Commands.Admins
{
    public class MenuCommand : ICommand
    {
        public string Name => "/menu";

        public Task Execute(long chatId, ITelegramBotClient botClient)
        {
            throw new NotImplementedException();
        }
    }
}
