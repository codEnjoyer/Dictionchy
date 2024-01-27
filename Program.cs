using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Dictionchy.Handlers;

namespace Dictionchy
{
    public static class Program
    {
        private static readonly ITelegramBotClient Bot = new TelegramBotClient(DotEnv.Token);

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken)
        {
            await UpdateHandler.HandleUpdateAsync(botClient, update, cancellationToken);
        }

        private static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
            CancellationToken cancellationToken)
        {
            await ErrorHandler.HandleErrorAsync(botClient, exception, cancellationToken);
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