using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Commands;

namespace TelegramBot.Domain
{
    public class CommandsExecutor
    {
        private ITelegramBotClient _telegramBotClient;
        private List<ICommand> _commands;

        public CommandsExecutor(long userId, 
                                Rights right,
                                List<ICommand> commands,
                                ITelegramBotClient telegramBotClient) 
        {
            UserId = userId;
            Right = right;
            _commands = commands;
            _telegramBotClient = telegramBotClient;
        }

        public long UserId { get; }

        public Rights Right { get; }

        public async Task OnMessageRecieved(Message message)
        {
            if (string.IsNullOrWhiteSpace(message.Text))
            {
                return;
            }

            var text = message.Text.Split(' ')[0];
            var command = _commands.FirstOrDefault(command => command.Name == text);
            await command.Execute(message.Chat.Id, _telegramBotClient);
        }

        public async Task OnCallbackQueryRecieved(CallbackQuery callbackQuery)
        {

        }
    }
}
