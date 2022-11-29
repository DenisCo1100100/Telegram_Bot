using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;

namespace TelegramBot.Model.Commands
{
    class GetScheduleCommand : BaseCommand
    {
        public override string Name { get; set; } = "/schedule";

        public override async void Execute(MessageEventArgs e)
        {
            GetScreanSchot();

            InputOnlineFile imageFile = new InputOnlineFile(new MemoryStream(File.ReadAllBytes("Result.jpeg")));

            await Bot.BotClient.SendPhotoAsync(
                  chatId: e.Message.Chat,
                  photo: imageFile
                );
        }

        private Image GetScreanSchot()
        {
            MainMenuForm.Controller.Invoke((MethodInvoker)delegate
            {
                MainMenuForm.Controller.GetScreanShot(DateTime.Now.ToString());
            });

            return MainMenuForm.ScreanSchot;
        }
    }
}