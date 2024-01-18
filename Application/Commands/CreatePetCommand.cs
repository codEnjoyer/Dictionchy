using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class CreatePetCommand : ICommand
    {
        public string? Description => "Создаёт питомца для нового пользователя";

        public CommandResult Execute(Update? update = null)
        {
            if (update != null && update.Message?.Text != null && update.CallbackQuery != null)
            {
                var pet = Pet.GetOrCreatePet(update.Message.Text, update.CallbackQuery.From.Id.ToString());
                return new CommandResult("Поздравляю, у вас появился питомец!", new PetKeyboard());
            }
            return new CommandResult("Что-то пошло не так...");
        }
    }
}
