using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Dictionchy.Application.Commands;

namespace Dictionchy
{
    class Program
    {
        private static readonly ITelegramBotClient Bot = new TelegramBotClient(DotEnv.Token);
        private static readonly CommandManager CommandManager = new();

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            switch (update.Type)
            {
                case UpdateType.Message:
                    {
                        var message = update.Message;
                        var commandName = message?.Text?.ToLower();
                        if (CommandManager.LastCommand?.Name == "/setName")
                        {
                            commandName = "/createPet";
                        }

                        var commandResult = CommandManager.ExecuteCommand(commandName ?? "/empty", update);
                        if (message != null)
                        {
                            await botClient.SendTextMessageAsync(message.Chat,
                                commandResult.Message,
                                replyMarkup: commandResult.ReplyKeyboard?.GetKeyBoard());
                        }
                        return;
                    }

                case UpdateType.CallbackQuery:
                    {
                        var callbackQuery = update.CallbackQuery;
                        var callbackResult = CommandManager.ExecuteCommand(callbackQuery?.Data ?? "/empty");
                        if (callbackQuery != null && callbackQuery.Message != null)
                        {
                            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat,
                                callbackResult.Message,
                                replyMarkup: callbackResult.ReplyKeyboard?.GetKeyBoard(),
                                cancellationToken: cancellationToken);
                        }
                        return;
                    }
            }
        }

        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
            CancellationToken cancellationToken)
        {
            var msg = JsonSerializer.Serialize(exception);
            Console.WriteLine(msg);
            return Task.CompletedTask;
        }

        private static void Main()
        {
            DotEnv.Load(EnvFileType.Json);
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions();
            Bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}