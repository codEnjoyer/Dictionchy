using Telegram.Bot.Types;
using Dictionchy.Handlers;
using Dictionchy.Application.Keyboards;

namespace Dictionchy.Application.Commands
{
    public class CommandManager
    {
        internal ICommand? LastCommand { get; private set; }

        private Dictionary<string, ICommand> commands = new()//TODO: переделать, чтобы команды не нужно было добавлять в словарь
        {
            {"/start", new StartCommand()},
            {"/help", new HelpCommand()},
            {"/askname", new AskNameCommand()},
            {"/createpet", new CreatePetCommand()},
            {"/petstate", new PetStateCommand()},
            {"/petactions", new PetActionsCommand()},
            {"/feed", new PetFeedCommand()},
            {"/clean", new PetCleanCommand()},
            {"/sleep", new PetSleepCommand()},
        };

        public CommandResult ExecuteCommand(string? name, Update? update = null)
        {
            if (name is null || !commands.ContainsKey(name))
                throw new NotExistCommandException(update.Message.Chat);
                // return new CommandResult("Неизвестная команда", new StartKeyboard());

            LastCommand = commands[name];
            return commands[name].Execute(update);
        }
    }
}
