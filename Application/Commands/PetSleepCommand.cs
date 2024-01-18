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
    internal class PetSleepCommand : ICommand
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
