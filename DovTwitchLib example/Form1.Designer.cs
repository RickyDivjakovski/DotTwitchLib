
namespace DovTwitchLib_example
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.ChatPanel = new System.Windows.Forms.Panel();
            this.ChatMessage = new System.Windows.Forms.TextBox();
            this.SendChat = new System.Windows.Forms.Button();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.Viewers = new System.Windows.Forms.Label();
            this.OpenWebpage = new System.Windows.Forms.Button();
            this.ShowDebug = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.IRCPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.IRCMessage = new System.Windows.Forms.TextBox();
            this.SendIRC = new System.Windows.Forms.Button();
            this.IRCBox = new System.Windows.Forms.RichTextBox();
            this.TwitchClient = new DotTwitchLib.TwitchClient();
            this.ChatPanel.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            this.IRCPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChatBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChatBox.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.ChatBox.Location = new System.Drawing.Point(0, 0);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.ChatBox.Size = new System.Drawing.Size(585, 481);
            this.ChatBox.TabIndex = 0;
            this.ChatBox.Text = "";
            this.ChatBox.TextChanged += new System.EventHandler(this.ChatBox_TextChanged);
            // 
            // ChatPanel
            // 
            this.ChatPanel.Controls.Add(this.ChatMessage);
            this.ChatPanel.Controls.Add(this.SendChat);
            this.ChatPanel.Controls.Add(this.ChatBox);
            this.ChatPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChatPanel.Location = new System.Drawing.Point(0, 32);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(585, 515);
            this.ChatPanel.TabIndex = 1;
            // 
            // ChatMessage
            // 
            this.ChatMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ChatMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatMessage.Font = new System.Drawing.Font("Roboto", 12F);
            this.ChatMessage.ForeColor = System.Drawing.Color.White;
            this.ChatMessage.Location = new System.Drawing.Point(7, 487);
            this.ChatMessage.Name = "ChatMessage";
            this.ChatMessage.Size = new System.Drawing.Size(481, 27);
            this.ChatMessage.TabIndex = 0;
            this.ChatMessage.Text = "Testing DotTwitchLib";
            // 
            // SendChat
            // 
            this.SendChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(70)))), ((int)(((byte)(255)))));
            this.SendChat.Enabled = false;
            this.SendChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendChat.ForeColor = System.Drawing.Color.White;
            this.SendChat.Location = new System.Drawing.Point(494, 488);
            this.SendChat.Name = "SendChat";
            this.SendChat.Size = new System.Drawing.Size(82, 23);
            this.SendChat.TabIndex = 1;
            this.SendChat.Text = "Send Chat";
            this.SendChat.UseVisualStyleBackColor = false;
            this.SendChat.Click += new System.EventHandler(this.SendChat_Click);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.OpenWebpage);
            this.HeaderPanel.Controls.Add(this.ShowDebug);
            this.HeaderPanel.Controls.Add(this.ConnectButton);
            this.HeaderPanel.Controls.Add(this.Viewers);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(585, 32);
            this.HeaderPanel.TabIndex = 2;
            // 
            // Viewers
            // 
            this.Viewers.Dock = System.Windows.Forms.DockStyle.Right;
            this.Viewers.Font = new System.Drawing.Font("Roboto", 12F);
            this.Viewers.ForeColor = System.Drawing.Color.White;
            this.Viewers.Location = new System.Drawing.Point(408, 0);
            this.Viewers.Name = "Viewers";
            this.Viewers.Size = new System.Drawing.Size(177, 32);
            this.Viewers.TabIndex = 14;
            this.Viewers.Text = "🔴 Viewers: 0";
            this.Viewers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OpenWebpage
            // 
            this.OpenWebpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OpenWebpage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(70)))), ((int)(((byte)(255)))));
            this.OpenWebpage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenWebpage.ForeColor = System.Drawing.Color.White;
            this.OpenWebpage.Location = new System.Drawing.Point(183, 3);
            this.OpenWebpage.Name = "OpenWebpage";
            this.OpenWebpage.Size = new System.Drawing.Size(90, 23);
            this.OpenWebpage.TabIndex = 4;
            this.OpenWebpage.Text = "Chat Webpage";
            this.OpenWebpage.UseVisualStyleBackColor = false;
            this.OpenWebpage.Click += new System.EventHandler(this.OpenWebpage_Click);
            // 
            // ShowDebug
            // 
            this.ShowDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(70)))), ((int)(((byte)(255)))));
            this.ShowDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowDebug.ForeColor = System.Drawing.Color.White;
            this.ShowDebug.Location = new System.Drawing.Point(95, 3);
            this.ShowDebug.Name = "ShowDebug";
            this.ShowDebug.Size = new System.Drawing.Size(82, 23);
            this.ShowDebug.TabIndex = 3;
            this.ShowDebug.Text = "Show Debug";
            this.ShowDebug.UseVisualStyleBackColor = false;
            this.ShowDebug.Click += new System.EventHandler(this.ShowDebug_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(70)))), ((int)(((byte)(255)))));
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.ForeColor = System.Drawing.Color.White;
            this.ConnectButton.Location = new System.Drawing.Point(7, 3);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(82, 23);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // IRCPanel
            // 
            this.IRCPanel.Controls.Add(this.panel4);
            this.IRCPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IRCPanel.Location = new System.Drawing.Point(0, 547);
            this.IRCPanel.Name = "IRCPanel";
            this.IRCPanel.Size = new System.Drawing.Size(585, 3);
            this.IRCPanel.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.IRCMessage);
            this.panel4.Controls.Add(this.SendIRC);
            this.panel4.Controls.Add(this.IRCBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, -164);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(585, 167);
            this.panel4.TabIndex = 4;
            // 
            // IRCMessage
            // 
            this.IRCMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IRCMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.IRCMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IRCMessage.Font = new System.Drawing.Font("Roboto", 12F);
            this.IRCMessage.ForeColor = System.Drawing.Color.White;
            this.IRCMessage.Location = new System.Drawing.Point(7, 134);
            this.IRCMessage.Name = "IRCMessage";
            this.IRCMessage.Size = new System.Drawing.Size(481, 27);
            this.IRCMessage.TabIndex = 2;
            this.IRCMessage.Text = "IRC Message";
            // 
            // SendIRC
            // 
            this.SendIRC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendIRC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(70)))), ((int)(((byte)(255)))));
            this.SendIRC.Enabled = false;
            this.SendIRC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendIRC.ForeColor = System.Drawing.Color.White;
            this.SendIRC.Location = new System.Drawing.Point(494, 135);
            this.SendIRC.Name = "SendIRC";
            this.SendIRC.Size = new System.Drawing.Size(82, 23);
            this.SendIRC.TabIndex = 3;
            this.SendIRC.Text = "Send IRC";
            this.SendIRC.UseVisualStyleBackColor = false;
            this.SendIRC.Click += new System.EventHandler(this.SendIRC_Click);
            // 
            // IRCBox
            // 
            this.IRCBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.IRCBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IRCBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.IRCBox.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IRCBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.IRCBox.Location = new System.Drawing.Point(0, 0);
            this.IRCBox.Name = "IRCBox";
            this.IRCBox.ReadOnly = true;
            this.IRCBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.IRCBox.Size = new System.Drawing.Size(585, 128);
            this.IRCBox.TabIndex = 1;
            this.IRCBox.Text = "";
            this.IRCBox.TextChanged += new System.EventHandler(this.IRCBox_TextChanged);
            // 
            // TwitchClient
            // 
            this.TwitchClient.DebugMode = false;
            this.TwitchClient.OAuthToken = "oauth:w1mtu6ein3rryr2dk34ie66oigvwkz";
            this.TwitchClient.ReferenceColors = ((System.Collections.Generic.List<System.Drawing.Color>)(resources.GetObject("TwitchClient.ReferenceColors")));
            this.TwitchClient.TwitchChannel = "ttvbottestaccount";
            this.TwitchClient.UserName = "TTVBotTestAccount";
            this.TwitchClient.UseSSl = true;
            this.TwitchClient.OnUserJoined += new System.EventHandler<DotTwitchLib.UserJoinedEventArgs>(this.TwitchClient_OnUserJoined);
            this.TwitchClient.OnChannelMessage += new System.EventHandler<DotTwitchLib.ChannelMessageEventArgs>(this.TwitchClient_OnChannelMessage);
            this.TwitchClient.OnIRCMessage += new System.EventHandler<DotTwitchLib.ChannelMessageEventArgs>(this.TwitchClient_OnIRCMessage);
            this.TwitchClient.OnBotCommandExecuted += new System.EventHandler<DotTwitchLib.CommandEventArgs>(this.TwitchClient_OnBotCommandExecuted);
            this.TwitchClient.OnTwitchCommandExecuted += new System.EventHandler<DotTwitchLib.CommandEventArgs>(this.TwitchClient_OnTwitchCommandExecuted);
            this.TwitchClient.OnConnect += new System.EventHandler<System.EventArgs>(this.TwitchClient_OnConnect);
            this.TwitchClient.OnPing += new System.EventHandler<System.EventArgs>(this.TwitchClient_OnPing);
            this.TwitchClient.OnReturnDebugData += new System.EventHandler<DotTwitchLib.ReturnDebugDataEventArgs>(this.TwitchClient_OnReturnDebugData);
            this.TwitchClient.OnSentMessage += new System.EventHandler<DotTwitchLib.SentMessageEventArgs>(this.TwitchClient_OnSentMessage);
            this.TwitchClient.OnSentIRCMessage += new System.EventHandler<DotTwitchLib.SentMessageEventArgs>(this.TwitchClient_OnSentIRCMessage);
            this.TwitchClient.OnViewersUpdate += new System.EventHandler<DotTwitchLib.ViewerEventArgs>(this.TwitchClient_OnViewersUpdate);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(585, 550);
            this.Controls.Add(this.IRCPanel);
            this.Controls.Add(this.ChatPanel);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "Form1";
            this.Text = "DotTwitchLib Example";
            this.ChatPanel.ResumeLayout(false);
            this.ChatPanel.PerformLayout();
            this.HeaderPanel.ResumeLayout(false);
            this.IRCPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.Panel ChatPanel;
        private System.Windows.Forms.Button SendChat;
        private System.Windows.Forms.TextBox ChatMessage;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button OpenWebpage;
        private System.Windows.Forms.Button ShowDebug;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Panel IRCPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox IRCMessage;
        private System.Windows.Forms.Button SendIRC;
        private System.Windows.Forms.RichTextBox IRCBox;
        private DotTwitchLib.TwitchClient TwitchClient;
        private System.Windows.Forms.Label Viewers;
    }
}

