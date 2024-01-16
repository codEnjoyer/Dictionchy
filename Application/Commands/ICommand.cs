using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionchy.Application.Keyboards;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public interface ICommand
    {
        public CommandResult Execute(Update update = null);
        
        public string Name { get; }
        public string Description { get; }
    }
    
}
