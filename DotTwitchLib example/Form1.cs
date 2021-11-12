using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotTwitchLib;

namespace DotTwitchLib_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Button to open chat in web browser
        private void OpenWebpage_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.twitch.tv/popout/xd_dee_fn/chat?popout=");
        }

        // Show debug section
        private void ShowDebug_Click(object sender, EventArgs e)
        {
            this.Height = 759;
        }

        // Scroll to end of chatboxes upon writing data
        private void ChatBox_TextChanged(object sender, EventArgs e)
        {
            ChatBox.SelectionStart = ChatBox.Text.Length;
            ChatBox.ScrollToCaret();
        }

        private void IRCBox_TextChanged(object sender, EventArgs e)
        {
            IRCBox.SelectionStart = IRCBox.Text.Length;
            IRCBox.ScrollToCaret();
        }

        // Create a thread to check for messages without blocking UI
        private Thread ChatThread;

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ChatThread = new Thread(new ThreadStart(RunBot));
            ChatThread.IsBackground = true;
            ChatThread.Start();
        }

        // A seperate method needed for the new thread to call
        public void RunBot()
        {
            TwitchClient.Connect();
            while (true) TwitchClient.ReadMessage();
        }

        // Sending messages vie IRC and Twitch
        private void SendChat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ChatMessage.Text)) TwitchClient.SendChatMessage(ChatMessage.Text);
            ChatMessage.Text = "";
        }

        private void SendIRC_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(IRCMessage.Text)) TwitchClient.SendIRCMessage(IRCMessage.Text);
            IRCMessage.Text = "";

        }

        // Utilising events (Where magic happens)
        private void TwitchClient_OnBotCommandExecuted(object sender, DotTwitchLib.CommandEventArgs e)
        {
            // Created the "Roll Dice" game, if command is "!rolldice" it will call the rolldice method and generate random 1-6 number
            IRCBox.Text = IRCBox.Text + e.User + " executed " + e.Command + " with args " + e.Args + "\n";
            if (e.Command.ToLower() == "!rolldice")
            {
                RollDice(e.User);
            }
        }

        private void TwitchClient_OnChannelMessage(object sender, DotTwitchLib.ChannelMessageEventArgs e)
        {
            ChatBox.AppendText(e.Time, e.From, e.Message, Color.Gray, e.ReferenceColor, Color.White);
        }

        private void TwitchClient_OnConnect(object sender, EventArgs e)
        {
            SendChat.Enabled = true;
            SendIRC.Enabled = true;
            IRCBox.Text = IRCBox.Text + "Connected..\n";
        }

        private void TwitchClient_OnIRCMessage(object sender, DotTwitchLib.ChannelMessageEventArgs e)
        {
            IRCBox.AppendText(e.Message + "\n");
        }

        private void TwitchClient_OnPing(object sender, EventArgs e)
        {
            IRCBox.Text = IRCBox.Text + "server has been pinged\n";
        }

        private void TwitchClient_OnReturnDebugData(object sender, DotTwitchLib.ReturnDebugDataEventArgs e)
        {
            IRCBox.Text = IRCBox.Text + e.Message + "\n";
        }

        private void TwitchClient_OnSentIRCMessage(object sender, DotTwitchLib.SentMessageEventArgs e)
        {
            IRCBox.Text = IRCBox.Text + e.From + ": " + e.Message + "\n";
        }

        private void TwitchClient_OnSentMessage(object sender, DotTwitchLib.SentMessageEventArgs e)
        {
            IRCBox.Text = IRCBox.Text + e.From + " sent " + e.Message + "\n";
        }

        private void TwitchClient_OnTwitchCommandExecuted(object sender, DotTwitchLib.CommandEventArgs e)
        {
            IRCBox.Text = IRCBox.Text + e.User + " executed twitch command " + e.Command + " with args " + e.Args + "\n";
        }

        private void TwitchClient_OnViewersUpdate(object sender, DotTwitchLib.ViewerCountUpdateEventArgs e)
        {
            int viewerCount = e.Vips + e.Admins + e.GlobalMods + e.Moderators + e.Staff + e.Viewers;
            Viewers.Text = "🔴 Viewers: " + viewerCount;
        }

        // Additional rolldice method if "!rolldice" command is sent
        Random RandomGenerator = new Random();
        private void RollDice(string user)
        {
            TwitchClient.SendChatMessage("@" + user + " rolled a " + RandomGenerator.Next(1, 7));
        }


        // 601, 589
        private void TwitchClient_OnViewerJoin(object sender, ViewerJoinEventArgs e)
        {
            ViewersUpdateBox.Text = ViewersUpdateBox.Text + e.Name + " has JOINED \n";
        }

        private void TwitchClient_OnViewerLeave(object sender, ViewerLeaveEventArgs e)
        {
            ViewersUpdateBox.Text = ViewersUpdateBox.Text + e.Name + " has LEFT \n";
        }
    }
}
