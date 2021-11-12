using System.Drawing;

namespace DotTwitchLib
{
    // Create a chatter class
    public class Chatter
    {
        public string Name = string.Empty;
        public Color ReferenceColor = Color.White;

        public Chatter(string name)
        {
            Name = name;
        }

        public Chatter(string name, Color referenceColor)
        {
            Name = name;
            ReferenceColor = referenceColor;
        }
    }
}
