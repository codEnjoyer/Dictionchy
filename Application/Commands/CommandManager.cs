using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class CommandManager
    {
        internal ICommand? LastCommand { get; private set; }
        private Dictionary<string, ICommand> commands = new()//TODO: переделать, чтобы команды не нужно было добавлять в словарь
        {
            {"/start", new StartCommand()},
            { "/empty", new EmptyCommand() }
        };
        internal ICommand GetCommandByName(string name)
        {
            return commands[name];
        }
        public CommandResult ExecuteCommand(string name, Update? update = null)
        {
            LastCommand = commands[name];
            return commands[name].Execute(update);
        }
    }
}
