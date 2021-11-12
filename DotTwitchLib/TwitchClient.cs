using System;
using System.Linq;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net.Security;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace DotTwitchLib
{
    public class TwitchClient : Component
    {
        // Create properties
        private string oAuthToken = "";
        [Category("DotTwitchLib - Credentials"), Browsable(true), Description("OAuth token")]
        public string OAuthToken
        {
            get { return oAuthToken; }
            set { this.oAuthToken = value; }
        }

        private string userName = "";
        [Category("DotTwitchLib - Credentials"), Browsable(true), Description("Bot username")]
        public string UserName
        {
            get { return userName; }
            set { this.userName = value; }
        }

        private string twitchChannel = "";
        [Category("DotTwitchLib - Credentials"), Browsable(true), Description("Twitch channel to monitor")]
        public string TwitchChannel
        {
            get { return twitchChannel; }
            set { this.twitchChannel = value; }
        }

        private bool useSSl = true;
        [Category("DotTwitchLib - Settings"), Browsable(true), Description("Use SSL or not")]
        public bool UseSSl
        {
            get { return useSSl; }
            set { this.useSSl = value; }
        }

        private bool debugMode = false;
        [Category("DotTwitchLib - Settings"), Browsable(true), Description("Enable debug mode(Outputs all to OnReturnDebugData event)")]
        public bool DebugMode
        {
            get { return debugMode; }
            set { this.debugMode = value; }
        }

        private bool isConnected = false;
        [Category("DotTwitchLib - Settings"), Browsable(true), Description("Is connected to client")]
        public bool IsConnected { get { return isConnected; } }

        private List<Color> referenceColors = new List<Color> { Color.Blue, Color.Coral, Color.DodgerBlue, Color.SpringGreen, Color.YellowGreen, Color.Green, Color.OrangeRed, Color.Red, Color.Goldenrod, Color.HotPink, Color.CadetBlue, Color.SeaGreen, Color.Chocolate, Color.BlueViolet, Color.Firebrick };
        [Category("DotTwitchLib - Settings"), Browsable(true), Description("Randomized user reference colors")]
        public List<Color> ReferenceColors
        {
            get { return referenceColors; }
            set { this.referenceColors = value; }
        }

        private List<Viewer> viewers = new List<Viewer>();

        private List<Chatter> chatters = new List<Chatter>();
        [Category("DotTwitchLib - Viewers"), Browsable(true), Description("Returns people who have engaged in session")] 
        public List<Chatter> Chatters { get { return chatters; } }

        [Category("DotTwitchLib - Viewers"), Browsable(true), Description("Returns Vip viewers (Registered users)")]
        public List<Viewer> Vips
        {
            get
            {
                List<Viewer> returnData = new List<Viewer>();
                foreach (Viewer v in viewers) if (v.Type == ViewerType.Vip) returnData.Add(v);
                return returnData;
            }
        }

        [Category("DotTwitchLib - Viewers"), Browsable(true), Description("Returns Moderator viewers (Registered users)")]
        public List<Viewer> Moderators
        {
            get
            {
                List<Viewer> returnData = new List<Viewer>();
                foreach (Viewer v in viewers) if (v.Type == ViewerType.Moderator) returnData.Add(v);
                return returnData;
            }
        }

        [Category("DotTwitchLib - Viewers"), Browsable(true), Description("Returns Staff viewers (Registered users)")]
        public List<Viewer> Staff
        {
            get
            {
                List<Viewer> returnData = new List<Viewer>();
                foreach (Viewer v in viewers) if (v.Type == ViewerType.Staff) returnData.Add(v);
                return returnData;
            }
        }

        [Category("DotTwitchLib - Viewers"), Browsable(true), Description("Returns Admin viewers (Registered users)")]
        public List<Viewer> Admins
        {
            get
            {
                List<Viewer> returnData = new List<Viewer>();
                foreach (Viewer v in viewers) if (v.Type == ViewerType.Admin) returnData.Add(v);
                return returnData;
            }
        }

        [Category("DotTwitchLib - Viewers"), Browsable(true), Description("Returns Global mod viewers (Registered users)")]
        public List<Viewer> GlobalMods
        {
            get
            {
                List<Viewer> returnData = new List<Viewer>();
                foreach (Viewer v in viewers) if (v.Type == ViewerType.GlobalMod) returnData.Add(v);
                return returnData;
            }
        }

        [Category("DotTwitchLib - Viewers"), Browsable(true), Description("Returns Standard viewers (Registered users)")]
        public List<Viewer> StandardViewers
        {
            get
            {
                List<Viewer> returnData = new List<Viewer>();
                foreach (Viewer v in viewers) if (v.Type == ViewerType.Standard) returnData.Add(v);
                return returnData;
            }
        }

        [Category("DotTwitchLib - Viewers"), Browsable(true), Description("Returns all viewers (Registered users)")]
        public List<Viewer> AllViewers { get { return viewers; } }

        [Category("DotTwitchLib - Viewers"), Browsable(true), Description("Returns viewer count (Registered users)")]
        public int ViewerCount { get { return viewers.Count; } }
        

        // Create events
        private AsyncOperation BgOperation;

        [Category("DotTwitchLib"), Browsable(true), Description("When a message is posted")]
        public event EventHandler<ChannelMessageEventArgs> OnChannelMessage = delegate { };
        [Category("DotTwitchLib"), Browsable(true), Description("When an IRC message is posted")]
        public event EventHandler<ChannelMessageEventArgs> OnIRCMessage = delegate { };
        [Category("DotTwitchLib"), Browsable(true), Description("When a command is executed in chat with prefix \"!\"")]
        public event EventHandler<CommandEventArgs> OnBotCommandExecuted = delegate { };
        [Category("DotTwitchLib"), Browsable(true), Description("When a twitch command is executed in chat with prefix \"/\"")]
        public event EventHandler<CommandEventArgs> OnTwitchCommandExecuted = delegate { };
        [Category("DotTwitchLib"), Browsable(true), Description("When connected")]
        public event EventHandler<EventArgs> OnConnect = delegate { };
        [Category("DotTwitchLib"), Browsable(true), Description("When pinging the server")]
        public event EventHandler<EventArgs> OnPing = delegate { };
        [Category("DotTwitchLib"), Browsable(true), Description("When debug data is returned(debug mode must be enabled)")]
        public event EventHandler<ReturnDebugDataEventArgs> OnReturnDebugData = delegate { };
        [Category("DotTwitchLib"), Browsable(true), Description("When a message is sent by this library")]
        public event EventHandler<SentMessageEventArgs> OnSentMessage = delegate { };
        [Category("DotTwitchLib"), Browsable(true), Description("When an IRC message is sent by this library")]
        public event EventHandler<SentMessageEventArgs> OnSentIRCMessage = delegate { };
        [Category("DotTwitchLib"), Browsable(true), Description("When the viewer count is updated")]
        public event EventHandler<ViewerCountUpdateEventArgs> OnViewerCountUpdate = delegate { };
        [Category("DotTwitchLib"), Browsable(true), Description("When a viewer joins(will only apply for logged in twitch users)")]
        public event EventHandler<ViewerJoinEventArgs> OnViewerJoin = delegate { };
        [Category("DotTwitchLib"), Browsable(true), Description("When a viewer joins(will only apply for logged in twitch users)")]
        public event EventHandler<ViewerLeaveEventArgs> OnViewerLeave = delegate { };

        private void onChannelMessage(ChannelMessageEventArgs o) { BgOperation.Post(x => OnChannelMessage(this, (ChannelMessageEventArgs)x), o); }
        private void onIRCMessage(ChannelMessageEventArgs o) { BgOperation.Post(x => OnIRCMessage(this, (ChannelMessageEventArgs)x), o); }
        private void onBotCommandExecuted(CommandEventArgs o) { BgOperation.Post(x => OnBotCommandExecuted(this, (CommandEventArgs)x), o); }
        private void onTwitchCommandExecuted(CommandEventArgs o) { BgOperation.Post(x => OnTwitchCommandExecuted(this, (CommandEventArgs)x), o); }
        private void onConnect(EventArgs o) { BgOperation.Post(x => OnConnect(this, (EventArgs)x), o); }
        private void onPing(EventArgs o) { BgOperation.Post(x => OnPing(this, (EventArgs)x), o); }
        private void onReturnDebugData(ReturnDebugDataEventArgs o) { BgOperation.Post(x => OnReturnDebugData(this, (ReturnDebugDataEventArgs)x), o); }
        private void onSentMessage(SentMessageEventArgs o) { BgOperation.Post(x => OnSentMessage(this, (SentMessageEventArgs)x), o); }
        private void onSentIRCMessage(SentMessageEventArgs o) { BgOperation.Post(x => OnSentIRCMessage(this, (SentMessageEventArgs)x), o); }
        private void onViewerCountUpdate(ViewerCountUpdateEventArgs o) { BgOperation.Post(x => OnViewerCountUpdate(this, (ViewerCountUpdateEventArgs)x), o); }
        private void onViewerJoin(ViewerJoinEventArgs o) { BgOperation.Post(x => OnViewerJoin(this, (ViewerJoinEventArgs)x), o); }
        private void onViewerLeave(ViewerLeaveEventArgs o) { BgOperation.Post(x => OnViewerLeave(this, (ViewerLeaveEventArgs)x), o); }

        // Create other required objects
        private TcpClient tcpClient;
        private NetworkStream stream;
        private SslStream ssl;
        private StreamReader inputStream;
        private StreamWriter outputStream;
        private readonly Random RandomGenerator = new Random();
        private bool FirstRun = true;

        public enum ViewerType { Vip, Moderator, Staff, Admin, GlobalMod, Standard }

        // Initialize client
        public TwitchClient()
        {
            BgOperation = AsyncOperationManager.CreateOperation(null);
        }

        // Core funtions
        public void Connect()
        {
            if (useSSl)
            {
                tcpClient = new TcpClient("irc.twitch.tv", 6697);
                stream = tcpClient.GetStream();
                ssl = new SslStream(stream, false);
                ssl.AuthenticateAsClient("irc.chat.twitch.tv");
                inputStream = new StreamReader(ssl);
                outputStream = new StreamWriter(ssl);
            }
            else
            {
                tcpClient = new TcpClient("irc.twitch.tv", 6667);
                inputStream = new StreamReader(tcpClient.GetStream());
                outputStream = new StreamWriter(tcpClient.GetStream());
            }

            outputStream.WriteLine($"PASS {oAuthToken}");
            outputStream.WriteLine($"NICK {userName}");
            outputStream.WriteLine($"USER {userName} 8 * :{userName}");
            outputStream.WriteLine($"JOIN #{twitchChannel}");
            outputStream.Flush();

            SendIRCMessage("CAP REQ :twitch.tv/tags twitch.tv/commands");

            Task.Run(() => Ping());
            Task.Run(() => GetViewers());

            chatters.Add(new Chatter(userName, Color.DodgerBlue));
            chatters.Add(new Chatter(twitchChannel, Color.Orange));
        }

        public void SendChatMessage(string message)
        {
            outputStream.WriteLine($":{userName}!bot@bot.tmi.twitch.tv PRIVMSG #{twitchChannel} :{message}");
            outputStream.Flush();
            onSentMessage(new SentMessageEventArgs(twitchChannel, userName, message));
            Listener($"badge-info=0;badges=0;client-nonce=0;color=0;display-name={userName};emotes=0;first-msg=0;flags=0;id=0;mod=0;room-id=0;subscriber=0;tmi-sent-ts=6666666666;turbo=0;user-id=0;user-type=0:{userName}!{userName}@{userName}.tmi.twitch.tv PRIVMSG #{twitchChannel} :{message}");
        }

        public string SendIRCMessage(string message)
        {
            outputStream.WriteLine(message);
            outputStream.Flush();
            if (!message.StartsWith("PING")) onSentIRCMessage(new SentMessageEventArgs(twitchChannel, userName, message));
            return message;
        }

        public void ReadMessage()
        {
            string line = "";
            try { line = inputStream.ReadLine(); } catch { }
            Listener(line);
        }

        public void Ping()
        {
            while (true)
            {
                SendIRCMessage("PING irc.twitch.tv");
                onPing(null);
                Thread.Sleep(TimeSpan.FromMinutes(5));
            }
        }

        public void GetViewers()
        {
            while (true)
            {
                WebResponse response = WebRequest.Create($"https://tmi.twitch.tv/group/user/" + twitchChannel + "/chatters").GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string viewData = reader.ReadToEnd();

                reader.Close();
                reader.Dispose();
                response.Close();
                response.Dispose();

                viewData = viewData.Replace("\"", "").Split('{')[3].Split('}').First();

                List<Viewer> OldViewData = new List<Viewer>();
                List<Viewer> NewViewData = new List<Viewer>();
                if (viewers.Count > 0) foreach (Viewer oV in viewers) OldViewData.Add(oV);

                viewers.Clear();

                foreach (string viewer in viewData.Split(':')[2].Replace("[", "").Split(']').First().Split(',')) if (!string.IsNullOrWhiteSpace(viewer)) NewViewData.Add(new Viewer(viewer, ViewerType.Vip));
                foreach (string viewer in viewData.Split(':')[3].Replace("[", "").Split(']').First().Split(',')) if (!string.IsNullOrWhiteSpace(viewer)) NewViewData.Add(new Viewer(viewer, ViewerType.Moderator));
                foreach (string viewer in viewData.Split(':')[4].Replace("[", "").Split(']').First().Split(',')) if (!string.IsNullOrWhiteSpace(viewer)) NewViewData.Add(new Viewer(viewer, ViewerType.Staff));
                foreach (string viewer in viewData.Split(':')[5].Replace("[", "").Split(']').First().Split(',')) if (!string.IsNullOrWhiteSpace(viewer)) NewViewData.Add(new Viewer(viewer, ViewerType.Admin));
                foreach (string viewer in viewData.Split(':')[6].Replace("[", "").Split(']').First().Split(',')) if (!string.IsNullOrWhiteSpace(viewer)) NewViewData.Add(new Viewer(viewer, ViewerType.GlobalMod));
                foreach (string viewer in viewData.Split(':')[7].Replace("[", "").Split(']').First().Split(',')) if (!string.IsNullOrWhiteSpace(viewer)) NewViewData.Add(new Viewer(viewer, ViewerType.Standard));

                if (FirstRun) { OldViewData = NewViewData; FirstRun = false; }

                Viewer view;

                foreach (Viewer newView in NewViewData)
                {
                    bool newViewer = true;
                    view = newView;
                    foreach (Viewer oldView in OldViewData)
                    {
                        if (newView.Name == oldView.Name)
                        {
                            newViewer = false;
                            view = oldView; 
                            break;
                        }
                    }
                    viewers.Add(view);
                    if (newViewer) onViewerJoin(new ViewerJoinEventArgs(view));
                }

                foreach (Viewer oldView in OldViewData)
                {
                    bool viewerLeft = true;
                    view = oldView;
                    foreach (Viewer newView in NewViewData) if (newView.Name == oldView.Name) 
                        { 
                            viewerLeft = false;
                            break;
                        }
                    if (viewerLeft) onViewerLeave(new ViewerLeaveEventArgs(view));
                }

                onViewerCountUpdate(new ViewerCountUpdateEventArgs(Vips.Count, Moderators.Count, Staff.Count, Admins.Count, GlobalMods.Count, StandardViewers.Count));
                Thread.Sleep(TimeSpan.FromMinutes(2));
            }
        }

        // Parser
        public void Listener(string line)
        {
            if (line != null && !string.IsNullOrWhiteSpace(line) && !debugMode)
            {
                if (line.Split(' ')[1] == "001") { onConnect(null); isConnected = true; }
                else if (line.Contains(" PRIVMSG "))
                {
                    string DisplayName = line.Split(new[] { "display-name=" }, StringSplitOptions.None).Last().Split(';').First();
                    Color UserColor = HtmlToColor(line.Split(new[] { "color=" }, StringSplitOptions.None).Last().Split(';').First(), DisplayName);
                    string TmiSentTs = "";
                    try { TmiSentTs = UnixTimeToDateTime(Convert.ToInt64(line.Split(new[] { "tmi-sent-ts=" }, StringSplitOptions.None).Last().Split(';').First())).ToString("HH:mm"); } catch { TmiSentTs = DateTime.Now.ToString("HH:mm"); }
                    string Message = line.Split(new[] { $"#{twitchChannel} :" }, StringSplitOptions.None).Last();

                    bool userExists = false;
                    foreach (Chatter entry in chatters)
                    {
                        if (entry.Name == DisplayName)
                        {
                            userExists = true;
                            entry.ReferenceColor = UserColor;
                        }
                    }
                    if (!userExists) chatters.Add(new Chatter(DisplayName, UserColor));

                    onChannelMessage(new ChannelMessageEventArgs(twitchChannel, DisplayName, Message, UserColor));

                    if (Message.StartsWith("/"))
                    {
                        string args = "";
                        if (Message.Replace(Message.Split(' ').First(), "").Length > 0)
                        {
                            args = Message.Replace(Message.Split(' ').First(), "").Substring(1);
                        }
                        onTwitchCommandExecuted(new CommandEventArgs(twitchChannel, DisplayName, Message.Split(' ').First(), args));
                    }
                    else if (Message.StartsWith("!"))
                    {
                        string args = "";
                        if (Message.Replace(Message.Split(' ').First(), "").Length > 0)
                        {
                            args = Message.Replace(Message.Split(' ').First(), "").Substring(1);
                        }
                        onBotCommandExecuted(new CommandEventArgs(twitchChannel, DisplayName, Message.Split(' ').First(), args));
                    }
                }
                else onIRCMessage(new ChannelMessageEventArgs("", "", line, Color.White));
            }
            else onReturnDebugData(new ReturnDebugDataEventArgs(line));
        }

        //Helper methods
        public string GetWebpageData(string webpage)
        {
            WebResponse response = WebRequest.Create(webpage).GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string viewData = reader.ReadToEnd();

            reader.Close();
            reader.Dispose();
            response.Close();
            response.Dispose();

            return viewData;
        }

        public DateTime UnixTimeToDateTime(long unixtime)
        {
            if (unixtime == 6666666666) return DateTime.Now;
            else
            {
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddMilliseconds(unixtime).ToLocalTime();
                return dtDateTime;
            }
        }

        public Color HtmlToColor(string htmlcolor, string displayname)
        {
            if (htmlcolor != null && !string.IsNullOrWhiteSpace(htmlcolor) && htmlcolor.StartsWith("#")) return System.Drawing.ColorTranslator.FromHtml(htmlcolor);
            else
            {
                Color returnColor = RandomColor();
                foreach (Chatter entry in chatters)
                {
                    if (entry.Name == displayname)
                    {
                        returnColor = entry.ReferenceColor;
                    }
                }
                return returnColor;
            }
        }

        public Color RandomColor()
        {
            return referenceColors[RandomGenerator.Next(0, referenceColors.Count - 1)];
        }

        // Disposal
        protected override void Dispose(bool disposing)
        {
            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
            }
            if (ssl != null)
            {
                ssl.Close();
                ssl.Dispose();
            }
            if (inputStream != null)
            {
                inputStream.Close();
                inputStream.Dispose();
            }
            if (outputStream != null)
            {
                outputStream.Close();
                outputStream.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
