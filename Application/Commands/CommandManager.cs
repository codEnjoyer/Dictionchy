using Telegram.Bot;
using Telegram.Bot.Types;

namespace Dictionchy.Application.Commands
{
    public class CommandManager
    {
        internal ICommand? LastCommand { get; private set; }

        private Dictionary<string, ICommand> commands = new() //TODO: переделать, чтобы команды не нужно было добавлять в словарь
        {
            {"/start", new StartCommand()},
            {"/empty", new EmptyCommand()},
            {"/askname", new AskNameCommand()},
            {"/createpet", new CreatePetCommand()},
            {"/petstate", new PetStateCommand()},
            {"/petactions", new PetActionsCommand()},
            {"/feed", new PetFeedCommand()},
            {"/clean", new PetCleanCommand()},
            {"/sleep", new PetSleepCommand()},
        };
        private Dictionary<Type, string> nameByCommand = new()
        {
            {typeof(StartCommand), "/start"},
            {typeof(EmptyCommand), "/empty"},
            {typeof(AskNameCommand), "/askname"},
            {typeof(CreatePetCommand), "/createpet"},
            {typeof(PetStateCommand), "/petstate"},
            {typeof(PetActionsCommand), "/petactions"},
            {typeof(PetFeedCommand), "/feed"},
            {typeof(PetCleanCommand), "/clean"},
            {typeof(PetSleepCommand), "/sleep"},
        };
        private Dictionary<string, string> namesOnRussian = new()
        {
            {"/createpet", "создать питомца"},
            {"/askname", "ввести имя питомца"},
            {"/help", "помощь"},
            {"/petactions", "действия с питомцем"},
            {"/petstate", "состояние питомца"},
            {"/feed", "покормить"},
            {"/clean", "помыть"},
            {"/sleep", "уложить спать"},
            {"/speak", "поговорить"},
        };


        public ICommand GetCommandByContext(ITelegramBotClient client, Update update)
        {
            var message = update.Message;
            var messageText = message?.Text?.ToLower();
            if (namesOnRussian.ContainsKey(messageText))
                return commands[namesOnRussian[messageText]];
            return null;
        }

        public string? GetNameByCommand(ICommand command)
        {
            var type = command.GetType();
            return nameByCommand.ContainsKey(type) ? nameByCommand[type] : null;
        }
    }
}
