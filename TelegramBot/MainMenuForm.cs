using System;
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

        public MainMenuForm()
        {
            InitializeComponent();

            Controller = this;
        }

        private void usersTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            TabPage _tabPage = usersTabControl.TabPages[e.Index];

            Rectangle _tabBounds = usersTabControl.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);

            StringFormat _stringFlags = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

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

            RichTextBox chatRichTextBox = new RichTextBox
            {
                Text = $"\n{userName}: {e.Message.Text}",
                Name = "chatRichTextBox",
                ReadOnly = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            var tabPage = new TabPage(e.Message.Chat.FirstName);
            tabPage.Name = userName;
            tabPage.Controls.Add(chatRichTextBox);
            usersTabControl.TabPages.Add(tabPage);
        }

        public void AddMessageInChat(MessageEventArgs e)
        {
            string userName = e.Message.Chat.Username;
            var tabPage = usersTabControl.TabPages[userName];
            var richTextBox = (RichTextBox)tabPage.Controls[0];

            richTextBox.Text += $"\n{userName}: {e.Message.Text}";
        }
    }
}