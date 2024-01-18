using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    internal class PetStateCommand : ICommand
    {
        public string? Description => "Состояние питомца";

        public CommandResult Execute(Update update = null)
        {
            var pet = Pet.GetOrCreatePet("Name", update.CallbackQuery.From.Id.ToString());
            return new CommandResult(pet.GetStateString(), new PetKeyboard());
        }
    }
}
