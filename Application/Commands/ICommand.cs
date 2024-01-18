using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public interface ICommand
    {
        public CommandResult Execute(Update update = null);
        public string? Description { get; }
    }
}
