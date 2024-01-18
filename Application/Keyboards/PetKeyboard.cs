using Telegram.Bot.Types.ReplyMarkups;

namespace Dictionchy.Application.Keyboards
{
    public class PetKeyboard : Keyboard
    {
        public override KeyboardButton[] Buttons => new KeyboardButton[] { "/petActions", "/petInfo" };
    }
}
