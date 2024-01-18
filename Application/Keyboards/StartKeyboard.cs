using Telegram.Bot.Types.ReplyMarkups;

namespace Dictionchy.Application.Keyboards
{
    public class StartKeyboard : Keyboard
    {
        public override KeyboardButton[] Buttons => new KeyboardButton[] { "/askName", "/help"};
    }
}
