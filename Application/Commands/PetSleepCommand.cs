using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using Dictionchy.Infrastructure;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    internal class PetSleepCommand : SingletonEquals, ICommand
    {
        public CommandResult Execute(Update? update = null)
        {
            var pet = Pet.GetPetByUserId(update.Message.From.Id);
            if (pet != null)
            {
                pet.Sleep(1);
                return new CommandResult("Вы уложили питомца спать", new PetKeyboard());
            }
            return new CommandResult("У вас нет питомца", new StartKeyboard());
        }
    }
}
