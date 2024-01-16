using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace Dictionchy.Application.Keyboards
{
    public class PetKeyboard : Keyboard
    {
        public override InlineKeyboardButton[] Buttons => new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Посмотреть состояние питомца", callbackData: "/empty"), //petState || petInfo
            InlineKeyboardButton.WithCallbackData(text: "Перейти к действиям с питомцем", callbackData: "/empty"), //petActions
        };
    }
}
