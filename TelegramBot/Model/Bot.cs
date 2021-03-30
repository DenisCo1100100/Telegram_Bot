using System.Collections.Generic;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Args;
using TelegramBot.Model.Commands;

namespace TelegramBot.Model
{
    public class Bot
    {
        public static ITelegramBotClient BotClient { get; private set; }
        private static List<BaseCommand> _commandsList;
        //private delegate void MyDeleg(MessageEventArgs e);

        public Bot()
        {
            //Adding new command
            _commandsList = new List<BaseCommand>()
            {
                new HelloCommand(),
                new InformationCommand()
            };


        }

        public void Connection(string token)
        {
            BotClient = new TelegramBotClient(token);

            BotClient.OnMessage += Bot_OnMessage;
            BotClient.StartReceiving();
        }

        private void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            MainMenuForm.Controller.Invoke((MethodInvoker)delegate
            {
                MainMenuForm.Controller.AddUser(e);
            });

            string message = e.Message.Text;

            foreach (var command in _commandsList)
            {
                if (command.Name == message)
                {
                    command.Execute(e);

                    break;
                }
            }
        }
    }
}