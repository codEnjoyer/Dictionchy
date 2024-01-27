using Telegram.Bot.Types.ReplyMarkups;

namespace Dictionchy.Application.Keyboards
{
    public abstract class Keyboard
    {
        public IReplyMarkup GetKeyboardMarkup() => Buttons.Length > 0
            ? new ReplyKeyboardMarkup(Buttons)
            : new ReplyKeyboardRemove();

        public abstract KeyboardButton[] Buttons { get; }
    }
}