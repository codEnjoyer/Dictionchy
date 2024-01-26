using State_Machine;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public interface ICommand: ITrigger
    {
        public Update Context { get; set; }
        public ITelegramBotClient Client { get; set; }
    }
}
