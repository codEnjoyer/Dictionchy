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

            var isCommand = messageText.StartsWith("/");
            if (CommandManager.LastCommand is AskNameCommand && !isCommand)
            {
                messageText = "/createpet";
                isCommand = true;
            }

            if (isCommand) 
            {
                var commandResult = CommandManager.ExecuteCommand(messageText, update);
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
