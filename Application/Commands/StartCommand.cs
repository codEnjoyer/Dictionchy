using Dictionchy.Application.Keyboards;
using Dictionchy.Infrastructure;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class StartCommand : SingletonEquals, ICommand
    {
        public CommandResult Execute(Update? update = null)
        {
            return new CommandResult("Приветственное сообщение для замены", new StartKeyboard());
        }
    }
}
