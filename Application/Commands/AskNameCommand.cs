using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class AskNameCommand : ICommand
    {
        public string Name => "/askName";

        public string Description => null;

        public CommandResult Execute(Update update = null)
        {
            return new CommandResult("Введите имя питомца");
        }
    }
}
