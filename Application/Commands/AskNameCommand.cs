using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using Dictionchy.Infrastructure;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class AskNameCommand : SingletonEquals, ICommand
    {
        public Update Context { get; set; }
        public ITelegramBotClient Client { get; set; }

        public async void Execute()
        {
            var message = Context.Message;
            if (Pet.GetPetByUserId(message.From.Id) == null)
            {
                await Client.SendTextMessageAsync(message!.Chat,
                    "Введите имя питомца");
            }
            else
            {
                await Client.SendTextMessageAsync(message!.Chat,
                    "У вас уже есть питомец.",
                    replyMarkup: new PetKeyboard().GetKeyboard());
            }
        }
    }
}
