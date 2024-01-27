using Dictionchy.Application.Commands;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Dictionchy.Application;
using State_Machine;

namespace Dictionchy.Handlers
{
    public static class UpdateHandler
    {
        private static readonly CommandManager CommandManager = new();
        private static readonly StateMachine<ICommand, StatesRegister.State> _machine 
            = StatesRegister.RegisterStateMachine();
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    {
                        await HandleMessageAsync(botClient, update);
                        return;
                    }
            }
        }

        public static async Task HandleMessageAsync(ITelegramBotClient botClient, Update update)
        {
            _machine.HandleEvent(CommandManager.GetCommandByContext(botClient, update));
        }

    }
}
