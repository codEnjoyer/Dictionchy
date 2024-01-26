
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Dictionchy.Handlers
{
    public class NotExistCommandException : Exception
    {
        public Chat Chat { get; }
        public NotExistCommandException(Chat chat) {  Chat = chat; }
    }

    public static class ErrorHandler
    {
        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is NotExistCommandException)
            {
                return botClient.SendTextMessageAsync((exception as NotExistCommandException).Chat,
                "Эта функциональность пока не реализована");
            }
            return Task.CompletedTask;
        }
    }
}
