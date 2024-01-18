using Telegram.Bot.Types.ReplyMarkups;
using Dictionchy.Application.Commands;

namespace Dictionchy.Application.Keyboards
{
    public abstract class Keyboard
    {
        private CommandManager _manager = new();
        public ReplyKeyboardMarkup GetKeyBoard()
        {
            return new(Buttons);
        }

        public abstract KeyboardButton[] Buttons { get; }
    }
}
