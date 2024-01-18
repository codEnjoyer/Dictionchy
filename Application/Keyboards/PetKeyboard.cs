using Telegram.Bot.Types.ReplyMarkups;

namespace Dictionchy.Application.Keyboards
{
    public class PetKeyboard : Keyboard
    {
        public override InlineKeyboardButton[] Buttons => new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Посмотреть состояние питомца", callbackData: "/petState"), //petState || petInfo
            InlineKeyboardButton.WithCallbackData(text: "Перейти к действиям с питомцем", callbackData: "/empty"), //petActions
        };
    }
}
