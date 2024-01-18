using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Dictionchy.Handlers;
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
            await UpdateHandler.HandleUpdateAsync(botClient, update, cancellationToken);
        }

        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
            CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
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