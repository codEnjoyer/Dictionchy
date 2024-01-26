using Telegram.Bot.Types;
using Dictionchy.Infrastructure;

namespace Dictionchy.Application.Commands
{
    public class EmptyCommand : SingletonEquals, ICommand
    {
        public CommandResult Execute(Update? update = null)
        {
            return new CommandResult("Эта функциональность пока не реализована");
        }
    }
}
