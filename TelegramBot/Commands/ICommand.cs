using Telegram.Bot;

namespace TelegramBot.Commands
{
    public interface ICommand
    {
        public string Name { get; }

        public Task Execute(long chatId, ITelegramBotClient botClient);
    }
}
