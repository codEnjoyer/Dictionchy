using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class CommandManager
    {
        internal ICommand LastCommand { get; private set; }

        private Dictionary<string, ICommand> commands = new()//TODO: переделать, чтобы команды не нужно было добавлять в словарь
        {
            {"/start", new StartCommand()},
            {"/empty", new EmptyCommand()},
            {"/askName", new AskNameCommand()},
            {"/createPet", new CreatePetCommand()},
            {"/petState", new PetStateCommand()}
        };

        internal ICommand GetCommandByName(string name)
        {
            return commands[name];
        }

        public CommandResult ExecuteCommand(string name, Update update = null)
        {
            if (!commands.ContainsKey(name)) 
                return commands["/empty"].Execute(update);

            LastCommand = commands[name];
            return commands[name].Execute(update);
        }
    }
}
