using Dictionchy.Application.Keyboards;
using Dictionchy.Domain;
using Dictionchy.Infrastructure;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class StartCommand : ICommand
    {
        public Update Context { get; set; }
        public ITelegramBotClient Client { get; set; }
        public async void Execute()
        {
            await Client.SendTextMessageAsync(Context.Message!.Chat,
                    "Привет-привет, чтобы начать пользоваться тебе нужно создать питомца!",
                    replyMarkup: new StartKeyboard().GetKeyboard());
        }
    }
}
