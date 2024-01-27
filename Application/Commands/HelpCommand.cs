using Dictionchy.Application.Keyboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    internal class HelpCommand : ICommand
    {
        public CommandResult Execute(Update? update = null)
        {
            return new CommandResult(
                "Бот, который мотивирует пользователя улучшать чистоту своей речи. " +
                "Каждый пользователь может взаимодействовать со своим питомцем: " +
                "кормить, ухаживать, отправить спать, и самое главное - разговаривать. " +
                "На сообщения пользователя бот будет реагировать в зависимости от того, насколько \"чистой\" была реплика: " +
                "радоваться и продолжать беседу или грустить и не понимать хозяина.", 
                new StartKeyboard()
           );
        }
    }
}
