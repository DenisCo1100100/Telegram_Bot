
namespace TelegramBot
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.usersTabControl = new System.Windows.Forms.TabControl();
            this.controllersGroupBox = new System.Windows.Forms.GroupBox();
            this.startButton = new System.Windows.Forms.Button();
            this.tokenLabel = new System.Windows.Forms.Label();
            this.tokenTextBox = new System.Windows.Forms.TextBox();
            this.controllersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // usersTabControl
            // 
            this.usersTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.usersTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.usersTabControl.ItemSize = new System.Drawing.Size(10, 200);
            this.usersTabControl.Location = new System.Drawing.Point(12, 23);
            this.usersTabControl.Multiline = true;
            this.usersTabControl.Name = "usersTabControl";
            this.usersTabControl.SelectedIndex = 0;
            this.usersTabControl.Size = new System.Drawing.Size(856, 406);
            this.usersTabControl.TabIndex = 0;
            this.usersTabControl.Tag = "";
            this.usersTabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.usersTabControl_DrawItem);
            // 
            // controllersGroupBox
            // 
            this.controllersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.controllersGroupBox.Controls.Add(this.startButton);
            this.controllersGroupBox.Controls.Add(this.tokenLabel);
            this.controllersGroupBox.Controls.Add(this.tokenTextBox);
            this.controllersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.controllersGroupBox.Location = new System.Drawing.Point(261, 435);
            this.controllersGroupBox.Name = "controllersGroupBox";
            this.controllersGroupBox.Size = new System.Drawing.Size(366, 119);
            this.controllersGroupBox.TabIndex = 1;
            this.controllersGroupBox.TabStop = false;
            this.controllersGroupBox.Text = "Управление ботом";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(136, 84);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(107, 29);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Запустить";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // tokenLabel
            // 
            this.tokenLabel.AutoSize = true;
            this.tokenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tokenLabel.Location = new System.Drawing.Point(6, 22);
            this.tokenLabel.Name = "tokenLabel";
            this.tokenLabel.Size = new System.Drawing.Size(226, 24);
            this.tokenLabel.TabIndex = 3;
            this.tokenLabel.Text = "Токен для подключения";
            // 
            // tokenTextBox
            // 
            this.tokenTextBox.BackColor = System.Drawing.Color.White;
            this.tokenTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tokenTextBox.Location = new System.Drawing.Point(6, 49);
            this.tokenTextBox.Name = "tokenTextBox";
            this.tokenTextBox.Size = new System.Drawing.Size(354, 29);
            this.tokenTextBox.TabIndex = 2;
            this.tokenTextBox.Text = "1720851055:AAFvm9HFnPJB5hc_d4Z6Z0Q4i4-aRJTetko";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 566);
            this.Controls.Add(this.controllersGroupBox);
            this.Controls.Add(this.usersTabControl);
            this.Name = "MainMenuForm";
            this.Text = "Управление ботом";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.controllersGroupBox.ResumeLayout(false);
            this.controllersGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl usersTabControl;
        private System.Windows.Forms.GroupBox controllersGroupBox;
        private System.Windows.Forms.Label tokenLabel;
        private System.Windows.Forms.TextBox tokenTextBox;
        private System.Windows.Forms.Button startButton;
    }
}