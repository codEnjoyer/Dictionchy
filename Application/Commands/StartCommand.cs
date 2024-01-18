using Dictionchy.Application.Keyboards;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class StartCommand : ICommand
    {
        public string? Description => "";

        public CommandResult Execute(Update update = null)
        {
            return new CommandResult("Приветственное сообщение для замены", new StartKeyboard());
        }
    }
}
