using System;
using System.Drawing;

namespace DotTwitchLib
{
    // Create event args

    public class UserJoinedEventArgs : EventArgs
    {
        public string Channel { get; internal set; }
        public string User { get; internal set; }
        public string Time { get; internal set; }

        public UserJoinedEventArgs(string channel, string user)
        {
            this.Time = DateTime.Now.ToString("HH:mm");
            this.Channel = channel;
            this.User = user;
        }
    }

    public class ReturnDebugDataEventArgs : EventArgs
    {
        public string Message { get; internal set; }
        public string Time { get; internal set; }

        public ReturnDebugDataEventArgs(string message)
        {
            this.Time = DateTime.Now.ToString("HH:mm");
            this.Message = message;
        }
    }

    public class CommandEventArgs : EventArgs
    {
        public string Channel { get; internal set; }
        public string User { get; internal set; }
        public string Command { get; internal set; }
        public string Args { get; internal set; }
        public string Time { get; internal set; }

        public CommandEventArgs(string channel, string user, string command, string args)
        {
            this.Time = DateTime.Now.ToString("HH:mm");
            this.Channel = channel;
            this.User = user;
            this.Command = command;
            this.Args = args;
        }
    }

    public class ViewerEventArgs : EventArgs
    {
        public int Vips { get; internal set; }
        public int Moderators { get; internal set; }
        public int Staff { get; internal set; }
        public int Admins { get; internal set; }
        public int GlobalMods { get; internal set; }
        public int Viewers { get; internal set; }

        public ViewerEventArgs(int vips, int moderators, int staff, int admins, int globalmods, int viewers)
        {
            this.Vips = vips;
            this.Moderators = moderators;
            this.Staff = staff;
            this.Admins = admins;
            this.GlobalMods = globalmods;
            this.Viewers = viewers;
        }
    }

    public class StringEventArgs : EventArgs
    {
        public string Result { get; internal set; }
        public string Time { get; internal set; }

        public StringEventArgs(string s)
        {
            this.Time = DateTime.Now.ToString("HH:mm");
            Result = s;
        }

        public override string ToString()
        {
            return Result;
        }
    }

    public class ChannelMessageEventArgs : EventArgs
    {
        public string Channel { get; internal set; }
        public string From { get; internal set; }
        public string Message { get; internal set; }
        public string Time { get; internal set; }
        public Color ReferenceColor { get; internal set; }

        public ChannelMessageEventArgs(string channel, string from, string message, Color referenceColor)
        {
            this.Time = DateTime.Now.ToString("HH:mm");
            this.Channel = channel;
            this.From = from;
            this.Message = message;
            this.ReferenceColor = referenceColor;
        }
        public ChannelMessageEventArgs(string channel, string from, string message)
        {
            this.Time = DateTime.Now.ToString("HH:mm");
            this.Channel = channel;
            this.From = from;
            this.Message = message;
            this.ReferenceColor = Color.White;
        }
    }

    public class SentMessageEventArgs : EventArgs
    {
        public string Channel { get; internal set; }
        public string From { get; internal set; }
        public string Message { get; internal set; }
        public string Time { get; internal set; }
        public Color ReferenceColor { get; internal set; }

        public SentMessageEventArgs(string channel, string from, string message, Color referenceColor)
        {
            this.Time = DateTime.Now.ToString("HH:mm");
            this.Channel = channel;
            this.From = from;
            this.Message = message;
            this.ReferenceColor = referenceColor;
        }
        public SentMessageEventArgs(string channel, string from, string message)
        {
            this.Time = DateTime.Now.ToString("HH:mm");
            this.Channel = channel;
            this.From = from;
            this.Message = message;
            this.ReferenceColor = Color.White;
        }
    }
}
