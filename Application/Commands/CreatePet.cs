using Dictionchy.Application.Keyboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class CreatePet : ICommand
    {
        public string Name => "/createPet";

        public string Description => "Создаёт питомца для нового пользователя";

        public CommandResult Execute(Update update = null)
        {
            var pet = Pet.GetOrCreatePet(update.Message.Text, update.CallbackQuery.From.Id.ToString());
            return new CommandResult("Поздравляю, у вас появился питомец!", new PetKeyboard());
        }
    }
}
