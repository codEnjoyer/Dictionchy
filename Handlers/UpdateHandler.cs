using Dictionchy.Application.Commands;
using Dictionchy.Application.Keyboards;
using SpeechPurifier.Analyzer;
using SpeechPurifier.Improver;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace Dictionchy.Handlers
{
    public static class UpdateHandler
    {
        private static readonly CommandManager CommandManager = new(); //TODO: добавить в контейнер
        private static TextAnalyzer _textAnalyzer = new();
        private static TextImprover _textImprover = new();
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
                    replyMarkup: commandResult.ReplyKeyboard?.GetKeyboardMarkup());
            }
            else
            {
                var analyzeResult = _textAnalyzer.Analyze(messageText);
                var recommendation = _textImprover.GetRecommendation(analyzeResult);
                var answer = string.IsNullOrEmpty(recommendation)
                    ? "Супер, расскажешь что-нибудь еще?"
                    : recommendation;
                await botClient.SendTextMessageAsync(message!.Chat,
                    answer,
                    replyMarkup: new PetKeyboard().GetKeyboardMarkup());
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
                    replyMarkup: callbackResult.ReplyKeyboard?.GetKeyboardMarkup(),
                    cancellationToken: cancellationToken);
            }
        }
    }
}
