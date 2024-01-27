using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

using Dictionchy.Infrastructure;
using Telegram.Bot;

namespace Dictionchy.Application.Commands
{
    internal class PetCleanCommand : ICommand
    {
        public Update Context { get; set; }
        public ITelegramBotClient Client { get; set; }

        public async void Execute()
        {
            var message = Context.Message;
            var pet = Pet.GetPetByUserId(message.From.Id);
            pet.Clean();
            await Client.SendTextMessageAsync(message.Chat,
                    "Вы умыли питомца",
                    replyMarkup: KeyboardGenerator.GenerateKeyboard());
        }
    }
}
