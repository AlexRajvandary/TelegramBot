using Telegram.Bot;

namespace TelegramBot.Commands.Admins
{
    public class CreateBroadcastCommand : ICommand
    {
        public string Name => "/createBroadcast";

        public Task Execute(long chatId, ITelegramBotClient botClient)
        {
            throw new NotImplementedException();
        }
    }
}
