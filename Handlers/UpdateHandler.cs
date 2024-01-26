using Dictionchy.Application.Commands;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace Dictionchy.Handlers
{
    public static class UpdateHandler
    {
        private static readonly CommandManager CommandManager = new(); //TODO: добавить в контейнер
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

                case UpdateType.CallbackQuery:
                    {
                        await HandleCallbackQueryAsync(botClient, update, cancellationToken);
                        return;
                    }
            }
        }

        public static async Task HandleMessageAsync(ITelegramBotClient botClient, Update update)
        {
            var message = update.Message;
            var commandName = message?.Text?.ToLower();
            var isCommand = commandName.StartsWith("/");
            if (CommandManager.LastCommand is AskNameCommand && !isCommand)
            {
                commandName = "/createpet";
                isCommand = true;
            }

            if (isCommand) 
            {
                
                var commandResult = CommandManager.ExecuteCommand(commandName, update);
                await botClient.SendTextMessageAsync(message!.Chat,
                    commandResult.Message,
                    replyMarkup: commandResult.ReplyKeyboard?.GetKeyboard());
            }
        }

        public static async Task HandleCallbackQueryAsync
            (ITelegramBotClient botClient, 
            Update update, 
            CancellationToken cancellationToken)
        {
            var callbackQuery = update.CallbackQuery;
            var callbackResult = CommandManager.ExecuteCommand(callbackQuery?.Data);
            if (callbackQuery is {Message: not null})
            {
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat,
                    callbackResult.Message,
                    replyMarkup: callbackResult.ReplyKeyboard?.GetKeyboard(),
                    cancellationToken: cancellationToken);
            }
        }
    }
}
