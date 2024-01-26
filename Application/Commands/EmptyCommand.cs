using Telegram.Bot.Types;
using Dictionchy.Infrastructure;
using Telegram.Bot;

namespace Dictionchy.Application.Commands
{
    public class EmptyCommand : ICommand
    {
        public Update Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITelegramBotClient Client { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public CommandResult Execute(Update? update = null)
        {
            return new CommandResult("Эта функциональность пока не реализована");
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
