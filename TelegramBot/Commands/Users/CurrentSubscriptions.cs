﻿using Telegram.Bot;

namespace TelegramBot.Commands.Users
{
    public class CurrentSubscriptions : ICommand
    {
        public string Name => "/currentSubscriptions";

        public Task Execute(long chatId, ITelegramBotClient botClient)
        {
            throw new NotImplementedException();
        }
    }
}
