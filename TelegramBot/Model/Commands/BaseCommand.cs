using Telegram.Bot.Args;

namespace TelegramBot.Model.Commands
{
    abstract class BaseCommand
    {
        public abstract string Name { get; set; }

        public abstract void Execute(MessageEventArgs e);
    }
}