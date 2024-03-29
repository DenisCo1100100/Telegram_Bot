﻿using Telegram.Bot.Args;

namespace TelegramBot.Model.Commands
{
    class InformationCommand : BaseCommand
    {
        public override string Name { get; set; } = "/info";

        public override async void Execute(MessageEventArgs e)
        {
            await Bot.BotClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: $"Я бот, написанный на C#. Мой батя @DenisKod1\n" +
                        $"Подписывайтесь на его инсту: www.instagram.com/denis_kozik1"
                );
        }
    }
}
