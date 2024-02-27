using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Commands;
using TelegramBot.Commands.Admins;
using TelegramBot.Domain;

namespace TelegramBot.Services
{
    public class TelegramBotService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly UserService _userService;

        private Dictionary<long, CommandsExecutor> chats = [];
        private List<ICommand> adminCommands = new List<ICommand>() { new StartCommand(), };
        private List<ICommand> userCommands = new List<ICommand>();

        public TelegramBotService(ITelegramBotClient botClient, UserService userService)
        {
            _botClient = botClient;
            _userService = userService;
        }

        public async Task ProcessUpdate(Update update)
        {
            if(update == null) return;  

            switch (update.Type)
            {
                case UpdateType.Message:
                case UpdateType.EditedMessage:
                    var commandExecutor = TryGetCommandExecutorOrCreateNew(update.Message.From.Id);
                    await commandExecutor.OnMessageRecieved(update.Message);
                    break;
                case UpdateType.CallbackQuery:
                    var commandExecutor2 = TryGetCommandExecutorOrCreateNew(update.CallbackQuery.From.Id);
                    await commandExecutor2.OnCallbackQueryRecieved(update.CallbackQuery);
                    break;
            }
        }

        private CommandsExecutor TryGetCommandExecutorOrCreateNew(long userId)
        {
            if(!chats.TryGetValue(userId, out var commandsExecutor))
            {
                commandsExecutor = CreateCommandExecutor(userId);
                chats.Add(userId, commandsExecutor);
            }

            return commandsExecutor;
        }

        private CommandsExecutor CreateCommandExecutor(long userId)
        {
            var isUserAdmin = _userService.IsUserAdmin(userId);
            if (isUserAdmin)
            {
                return new CommandsExecutor(userId, Rights.Admin, adminCommands, _botClient);
            }
            else
            {
                return new CommandsExecutor(userId, Rights.User, userCommands, _botClient);
            }
        }
    }
}
