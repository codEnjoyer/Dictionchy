using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class EmptyCommand : ICommand
    {
        public string? Description => "";

        public CommandResult Execute(Update update = null)
        {
            return new CommandResult("Эта функциональность пока не реализованна");
        }
    }
}
