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
    internal class PetFeedCommand : SingletonEquals, ICommand
    {
        public CommandResult Execute(Update? update = null)
        {
            var pet = Pet.GetPetByUserId(update.Message.From.Id);
            if (pet != null)
            {
                pet.Eat();
                return new CommandResult("Вы покормили питомца", new PetKeyboard());
            }
            return new CommandResult("У вас нет питомца", new StartKeyboard());
        }
    }
}
