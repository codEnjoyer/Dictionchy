using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class AskNameCommand : ICommand
    {
        public CommandResult Execute(Update? update = null)
        {
            if (Pet.GetPetByUserId(update.Message.From.Id) == null)
                return new("Введите имя питомца");
            return new("У вас уже есть питомец.", new PetKeyboard());
        }
    }
}
