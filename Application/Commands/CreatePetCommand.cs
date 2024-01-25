using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class CreatePetCommand : ICommand
    {
        public CommandResult Execute(Update? update = null)
        {
            if (update != null && update.Message?.Text != null)
            {
                var userId = update.Message.From.Id;

                if (Pet.GetPetByUserId(userId) != null)
                    return new CommandResult("У вас уже есть питомец", new PetKeyboard());

                Pet.CreatePet(update.Message.Text, userId);
                return new CommandResult("Поздравляю, у вас появился питомец!", new PetKeyboard());
            }
            return new CommandResult("Что-то пошло не так...");
        }
    }
}
