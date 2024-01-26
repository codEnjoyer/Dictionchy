using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

using Dictionchy.Infrastructure;

namespace Dictionchy.Application.Commands
{
    internal class PetCleanCommand : SingletonEquals, ICommand
    {
        public CommandResult Execute(Update? update = null)
        {
            var pet = Pet.GetPetByUserId(update.Message.From.Id);
            if (pet != null)
            {
                pet.Clean();
                return new CommandResult("Вы умыли питомца", new PetKeyboard());
            }
            return new CommandResult("У вас нет питомца", new StartKeyboard());
        }
    }
}
