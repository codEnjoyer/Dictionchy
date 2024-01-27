using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using Dictionchy.Infrastructure;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    internal class PetCreatedCommand : ICommand
    {
        public Update Context { get; set; }
        public ITelegramBotClient Client { get; set; }

        public async void Execute()
        {
            var message = Context.Message;
            await Client.SendTextMessageAsync(message!.Chat,
                "Ваш питомец успешно создан!", 
                replyMarkup: new PetKeyboard().GetKeyboard());
        }
    }
}
