using Dictionchy.Application.Keyboards;

namespace Dictionchy.Application.Commands
{
    public class CommandResult
    {
        public string Message { get; }
        public Keyboard ReplyKeyboard { get; }
        public CommandResult(string message, Keyboard keyboard)
        {
            Message = message;
            ReplyKeyboard = keyboard;
        }
        
        public CommandResult(string message) : this(message, new EmptyKeyboard()) { }
    }
}
