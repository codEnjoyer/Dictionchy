using Dictionchy.Infrastructure;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    internal class PetCreatedCommand : SingletonEquals, ICommand
    {
        public CommandResult Execute(Update? update = null)
        {
            return new CommandResult("Ваш питомец успешно создан!");
        }
    }
}
