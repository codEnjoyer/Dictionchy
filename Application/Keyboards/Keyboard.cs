using Telegram.Bot.Types.ReplyMarkups;
using Dictionchy.Application.Commands;

namespace Dictionchy.Application.Keyboards
{
    public abstract class Keyboard
    {
        private CommandManager _manager = new CommandManager();
        public InlineKeyboardMarkup GetKeyBoard()
        {
            //var bot = new TelegramBotClient("") { Timeout = TimeSpan.FromSeconds(10) };
            //bot.AnswerInlineQueryAsync += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
            //{
            //    _manager.GetCommandByName(ev.CallbackQuery.Data).Execute();
            //};
            return new(Buttons);
        }

        public abstract InlineKeyboardButton[] Buttons { get; }
    }
}
