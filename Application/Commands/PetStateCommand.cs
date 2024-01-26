using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dictionchy.Infrastructure;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    internal class PetStateCommand : SingletonEquals, ICommand
    {
        public CommandResult Execute(Update update = null)
        {
            var pet = Pet.GetPetByUserId(update.Message.From.Id);
            if (pet != null)
                return new CommandResult(pet.GetStateString(), new PetKeyboard());
            return new CommandResult("У вас нет питомца", new StartKeyboard());
        }
    }
}
