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
        public static List<long> UsersIdList { get; set; } = new List<long>();

        private static List<BaseCommand> _commandsList;

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
            Initialization(e);

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

        private void Initialization(MessageEventArgs e)
        {
            if (UsersIdList.Contains(e.Message.Chat.Id))
            {
                MainMenuForm.Controller.Invoke((MethodInvoker)delegate
                {
                    MainMenuForm.Controller.AddMessageInChat(e);
                });
            }
            else
            {
                UsersIdList.Add(e.Message.Chat.Id);

                MainMenuForm.Controller.Invoke((MethodInvoker)delegate
                {
                    MainMenuForm.Controller.AddUser(e);
                });
            }
        }
    }
}