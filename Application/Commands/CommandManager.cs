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
        private Dictionary<string, string> namesFromRussian = new()
        {
            {"создать питомца", "/createpet"},
            {"ввести имя питомца", "/askname"},
            {"помощь" , "/help"},
            {"действия с питомцем" , "/petactions"},
            {"состояние питомца" , "/petstate"},
            {"покормить" , "/feed"},
            {"помыть" , "/clean"},
            {"уложить спать" , "/sleep"},
            {"поговорить" , "/speak"},
        };


        public ICommand GetCommandByContext(ITelegramBotClient client, Update update)
        {
            var message = update.Message;
            var messageText = message?.Text?.ToLower();
            if (messageText.StartsWith('/'))
            {
                messageText = namesOnRussian.ContainsKey(messageText) ? namesOnRussian[messageText] : "";
            }
            if (namesFromRussian.ContainsKey(messageText))
                return commands[namesFromRussian[messageText]];
            return null;
        }

        public string? GetNameByCommand(ICommand command)
        {
            var type = command.GetType();
            return nameByCommand.ContainsKey(type) ? nameByCommand[type] : null;
        }
    }
}
