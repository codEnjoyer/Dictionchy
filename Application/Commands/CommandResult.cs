using Dictionchy.Application.Keyboards;

namespace Dictionchy.Application.Commands
{
    public class CommandResult
    {
        public string Message { get; }
        public Keyboard ReplyKeyboard { get; }
        public CommandResult(string message, Keyboard keyboard = null)
        {
            Message = message;
            ReplyKeyboard = keyboard;
        }
    }
}
