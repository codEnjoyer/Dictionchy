using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using Telegram.Bot.Types;
using Dictionchy.Infrastructure;
using Telegram.Bot;

namespace Dictionchy.Application.Commands
{
    public class CreatePetCommand : ICommand
    {
        public Update Context { get; set; }
        public ITelegramBotClient Client { get; set; }

        public async void Execute()
        {
            var message = Context?.Message;
            if (message?.Text != null)
            {
                var userId = message.From.Id;
                if (Pet.GetPetByUserId(userId) != null)
                {
                    await Client.SendTextMessageAsync(message!.Chat,
                    "У вас уже есть питомец");
                }
                else
                {
                    Pet.CreatePet(message.Text, userId);
                    await Client.SendTextMessageAsync(message!.Chat,
                    "Поздравляю, у вас появился питомец!", 
                    replyMarkup: KeyboardGenerator.GenerateKeyboard());
                }
            }
        }
    }
}
