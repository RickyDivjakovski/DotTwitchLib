using DotTwitchLib;
using System;

namespace DotTwitchLib
{
    // Create a chatter class
    public class Viewer
    {
        public string Name = string.Empty;
        public DateTime JoinTime;
        public TwitchClient.ViewerType Type;

        public Viewer(string name, TwitchClient.ViewerType type)
        {
            Name = name;
            JoinTime = DateTime.Now;
            Type = type;
        }
        public Viewer(string name, TwitchClient.ViewerType type, DateTime jointime)
        {
            Name = name;
            JoinTime = jointime;
            Type = type;
        }
    }
}
