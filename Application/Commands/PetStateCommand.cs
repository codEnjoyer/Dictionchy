using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dictionchy.Infrastructure;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace Dictionchy.Application.Commands
{
    internal class PetStateCommand : ICommand
    {
        public Update Context { get; set; }
        public ITelegramBotClient Client { get; set; }
        public async void Execute()
        {
            var pet = Pet.GetPetByUserId(Context.Message.From.Id);
            await Client.SendTextMessageAsync(Context.Message!.Chat,
                    pet.GetStateString(),
                    replyMarkup: KeyboardGenerator.GenerateKeyboard());
        }
    }
}
