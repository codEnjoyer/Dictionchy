using Dictionchy.Application.Keyboards;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class AskNameCommand : ICommand
    {
        public string? Description => null;

        public CommandResult Execute(Update? update = null) => 
            new("Введите имя питомца");
    }
}
