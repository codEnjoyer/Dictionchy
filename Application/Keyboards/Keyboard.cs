using Telegram.Bot.Types.ReplyMarkups;
using State_Machine;
using Dictionchy.Application.Commands;

namespace Dictionchy.Application.Keyboards
{
    public static class KeyboardGenerator
    {
        private static StateMachine<ICommand, StatesRegister.State> _machine = StatesRegister.RegisterStateMachine();
        private static CommandManager _commandManager = new CommandManager();

        public static IReplyMarkup GetKeyboard(KeyboardButton[] btns) => btns.Length > 0
            ? new ReplyKeyboardMarkup(btns)
            : new ReplyKeyboardRemove();

        public static IReplyMarkup GenerateKeyboard()
        {
            var commands = _machine.GetAllTriggers();
            return GetKeyboard(commands.Select(_commandManager.GetNameByCommand)
                .Select(x => new KeyboardButton(x))
                .ToArray());
        }
    }
}