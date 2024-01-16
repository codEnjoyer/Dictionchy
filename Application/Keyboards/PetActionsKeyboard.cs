using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace Dictionchy.Application.Keyboards
{
    public class PetActionsKeyboard : Keyboard
    {
        public override InlineKeyboardButton[] Buttons => new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Заглушка", callbackData: "/empty")
        };
    }
}
