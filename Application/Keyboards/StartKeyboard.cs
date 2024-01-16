using Telegram.Bot.Types.ReplyMarkups;

namespace Dictionchy.Application.Keyboards
{
    public class StartKeyboard : Keyboard
    {
        public override InlineKeyboardButton[] Buttons => new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Создать питомца", callbackData: "/setName"), 
            InlineKeyboardButton.WithCallbackData(text: "Что это за бот?", callbackData: "/empty"), //help
        };
    }
}
