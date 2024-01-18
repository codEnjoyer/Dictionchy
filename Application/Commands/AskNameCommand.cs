using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class AskNameCommand : ICommand
    {
        public string? Description => null;

        public CommandResult Execute(Update update = null)
        {
            return new CommandResult("Введите имя питомца");
        }
    }
}
