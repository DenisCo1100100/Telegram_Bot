using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;

namespace TelegramBot.Model.Commands
{
    class OtherCommand : BaseCommand
    {
        public override string Name { get; set; } = "other";

        public override async void Execute(MessageEventArgs e)
        {
            await Bot.BotClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: $"{e.Message.Chat.FirstName}, давайте будем разговаривать на понятном мне языке!!!"
                );
        }
    }
}
