using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Telegram.Bot.Args;
using TelegramBot.Model;

namespace TelegramBot
{
    public partial class MainMenuForm : Form
    {
        private readonly Bot _bot = new Bot();
        public static MainMenuForm Controller { get; set; }
        public static List<long> UsersIdList { get; set; } = new List<long>();

        public MainMenuForm()
        {
            InitializeComponent();

            Controller = this;

            foreach (TabPage page in usersTabControl.TabPages)
            {
                UsersIdList.Add(long.Parse(page.Tag.ToString()));
            }
        }

        private void usersTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = usersTabControl.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = usersTabControl.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (tokenTextBox.Text != "")
            {
                _bot.Connection(tokenTextBox.Text);
                tokenTextBox.BackColor = Color.White;
            }
            else
            {
                tokenTextBox.BackColor = Color.IndianRed;
            }
        }

        public void AddUser(MessageEventArgs e)
        {
            string userName = e.Message.Chat.Username;

            Label chatLabel = new Label();
            chatLabel.Text = $"\n{userName}: {e.Message.Text}";
            chatLabel.Name = "chatLabel";

            usersTabControl.TabPages.Add(new TabPage(userName));
            usersTabControl.TabPages[usersTabControl.TabPages.Count - 1].Controls.Add(chatLabel);
        }

        public void AddMessage(MessageEventArgs e)
        {
            string userName = e.Message.Chat.Username;

            usersTabControl.TabPages[userName].Controls.Find("chatLabel", true)[0].Text += $"\n{userName}: {e.Message.Text}";
        }
    }
}