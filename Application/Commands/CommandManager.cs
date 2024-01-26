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

        public ICommand GetCommandByContext(ITelegramBotClient client, Update update)
        {
            var message = update.Message;
            var messageText = message?.Text?.ToLower();
            switch (messageText)
            {
                case "создать питомца":
                    messageText = "/askname";
                    break;
                case "помощь":
                    messageText = "/help";
                    break;
                case "действия с питомцем":
                    messageText = "/petactions";
                    break;
                case "состояние питомца":
                    messageText = "/petstate";
                    break;
                case "покормить":
                    messageText = "/feed";
                    break;
                case "помыть":
                    messageText = "/clean";
                    break;
                case "уложить спать":
                    messageText = "/sleep";
                    break;
                case "поговорить":
                    messageText = "/speak";
                    break;
            }
            if (messageText.StartsWith("/") && commands.ContainsKey(messageText))
                return commands[messageText];
            return null;
        }
    }
}
