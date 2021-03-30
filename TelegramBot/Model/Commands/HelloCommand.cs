using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;

namespace TelegramBot.Model.Commands
{
    class HelloCommand : BaseCommand
    {
        public override string Name { get; set; } = "/hello";

        public override async void Execute(MessageEventArgs e)
        {
            await Bot.BotClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: $"{e.Message.Chat.Username}, Привет:)"
                );
        }
    }
}