using Dictionchy.Application.Keyboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
