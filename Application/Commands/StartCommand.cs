using Dictionchy.Application.Keyboards;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class StartCommand : ICommand
    {
        public CommandResult Execute(Update? update = null)
        {
            return new CommandResult(
                "Привет! Создай питомца, чтобы начать общаться",
                new StartKeyboard());
        }
    }
}
