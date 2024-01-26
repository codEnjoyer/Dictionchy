using Dictionchy.Application.Keyboards;
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
    internal  class PetActionsCommand : ICommand
    { 
        public Update Context { get; set; }
        public ITelegramBotClient Client { get; set; }

        public async void Execute()
        {
            var message = Context.Message;
            await Client.SendTextMessageAsync(message!.Chat,
                    "Выберите действие с питомцем",
                    replyMarkup: new PetActionsKeyboard().GetKeyboard());
        }
    }
}
