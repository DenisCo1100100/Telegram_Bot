using Awesomium.Core;
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
        public static Image ScreanSchot { get; private set; }

        private readonly WebView _webView = WebCore.CreateWebView(900, 1400);

        public MainMenuForm()
        {
            InitializeComponent();

            Controller = this;
        }

        public void AddUser(MessageEventArgs e)
        {
            string firstName = e.Message.Chat.FirstName;

            RichTextBox chatRichTextBox = new RichTextBox
            {
                Text = $"\n{firstName}: {e.Message.Text}",
                Name = "chatRichTextBox",
                ReadOnly = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            var tabPage = new TabPage(firstName);
            tabPage.Name = e.Message.Chat.Id.ToString();
            tabPage.Controls.Add(chatRichTextBox);
            usersTabControl.TabPages.Add(tabPage);
        }

        public void AddMessageInChat(MessageEventArgs e)
        {
            var tabPage = usersTabControl.TabPages[e.Message.Chat.Id.ToString()];
            var richTextBox = (RichTextBox)tabPage.Controls[0];

            richTextBox.Text += $"\n{e.Message.Chat.FirstName}: {e.Message.Text}";
        }

        public void GetScreanShot(string date)
        {
            _webView.Source = new Uri("http://pinskgptklp.brest.by/schedule/?type=replace&time=1617350605");

            _webView.LoadingFrameComplete += (s, es) =>
            {
                BitmapSurface surface = (BitmapSurface)_webView.Surface;
                surface.SaveToJPEG("Result.jpeg");
            };
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

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WebCore.Shutdown();
        }
    }
}