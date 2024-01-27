using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using Dictionchy.Infrastructure;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    internal class PetSleepCommand : ICommand
    {
        public Update Context { get; set; }
        public ITelegramBotClient Client { get; set; }
        public async void Execute()
        {
            var pet = Pet.GetPetByUserId(Context.Message.From.Id);
            pet.Sleep(1);
            await Client.SendTextMessageAsync(Context.Message!.Chat,
                    "Вы уложили питомца спать",
                    replyMarkup: KeyboardGenerator.GenerateKeyboard());
        }
    }
}
