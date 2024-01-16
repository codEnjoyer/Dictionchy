using Dictionchy.Application.Keyboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class StartCommand : ICommand
    {
        public string Name => "/start";

        public string Description => "";

        public CommandResult Execute(Update update = null)
        {
            return new CommandResult("Приветственное сообщение для замены", new StartKeyboard());
        }
    }
}
