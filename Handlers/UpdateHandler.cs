using Dictionchy.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Threading;

namespace Dictionchy.Handlers
{
    public static class UpdateHandler
    {
        private static CommandManager commandManager = new CommandManager();
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
            if (commandManager.LastCommand?.Name == "/setName")
            {
                commandName = "/createPet";
            }

            var commandResult = commandManager.ExecuteCommand(commandName ?? "/empty", update);
            if (message != null)
            {
                await botClient.SendTextMessageAsync(message.Chat,
                    commandResult.Message,
                    replyMarkup: commandResult.ReplyKeyboard?.GetKeyBoard());
            }
        }

        public static async Task HandleCallbackQueryAsync
            (ITelegramBotClient botClient, 
            Update update, 
            CancellationToken cancellationToken)
        {
            var callbackQuery = update.CallbackQuery;
            var callbackResult = commandManager.ExecuteCommand(callbackQuery?.Data ?? "/empty");
            if (callbackQuery != null && callbackQuery.Message != null)
            {
                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat,
                    callbackResult.Message,
                    replyMarkup: callbackResult.ReplyKeyboard?.GetKeyBoard(),
                    cancellationToken: cancellationToken);
            }
        }
    }
}
