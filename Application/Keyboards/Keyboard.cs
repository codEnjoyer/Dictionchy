using Telegram.Bot.Types.ReplyMarkups;
using Dictionchy.Application.Commands;

namespace Dictionchy.Application.Keyboards
{
    public abstract class Keyboard
    {
        private CommandManager _manager = new();
        public InlineKeyboardMarkup GetKeyBoard()
        {
            return new(Buttons);
        }

        public abstract InlineKeyboardButton[] Buttons { get; }
    }
}
