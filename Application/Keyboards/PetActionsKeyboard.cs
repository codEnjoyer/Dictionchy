using Telegram.Bot.Types.ReplyMarkups;

namespace Dictionchy.Application.Keyboards
{
    public class PetActionsKeyboard : Keyboard
    {
        public override KeyboardButton[] Buttons => new KeyboardButton[] 
        { 
            "Покормить", "Помыть", "Уложить спать", "Поговорить"
        };
    }
}
