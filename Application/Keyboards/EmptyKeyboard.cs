using Telegram.Bot.Types.ReplyMarkups;

namespace Dictionchy.Application.Keyboards;

public class EmptyKeyboard : Keyboard
{
    public override KeyboardButton[] Buttons => Array.Empty<KeyboardButton>();
}