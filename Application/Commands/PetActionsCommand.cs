using Dictionchy.Application.Keyboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Dictionchy.Infrastructure;

namespace Dictionchy.Application.Commands
{
    internal  class PetActionsCommand : SingletonEquals, ICommand
    {
        public CommandResult Execute(Update? update = null)
        {
            return new CommandResult("Выберите действие с питомцем", new PetActionsKeyboard());
        }
    }
}
