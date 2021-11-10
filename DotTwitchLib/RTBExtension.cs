using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DotTwitchLib
{
    public static class RichTextBoxExtensions
    {
        // Created for easier formatting
        public static void AppendText(this RichTextBox box, string time, string user, string message, Color timeColor, Color userColor, Color messageColor)
        {
            Font timeFont = new Font("Roboto", 10.0f);
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = timeColor;
            box.SelectionFont = timeFont;
            box.AppendText(time + " ");
            box.SelectionColor = box.ForeColor;
            box.SelectionFont = box.Font;

            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = userColor;
            box.AppendText(user + ": ");
            box.SelectionColor = box.ForeColor;

            if (message.Contains("@") && !message.Contains("@ "))
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.SelectionColor = messageColor;
                box.AppendText(message.Split(new[] { "@" }, StringSplitOptions.None).First());
                box.SelectionColor = box.ForeColor;

                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.SelectionColor = Color.FromArgb(24, 24, 24);
                box.SelectionBackColor = Color.FromArgb(247, 247, 247);
                box.AppendText("@" + message.Split(new[] { "@" }, StringSplitOptions.None).Last().Split(' ').First());
                box.SelectionColor = box.ForeColor;
                box.SelectionBackColor = box.BackColor;

                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.SelectionColor = messageColor;
                box.AppendText(message.Replace(message.Split(new[] { "@" }, StringSplitOptions.None).First() + "@" + message.Split(new[] { "@" }, StringSplitOptions.None).Last().Split(' ').First(), "") + "\n");
                box.SelectionColor = box.ForeColor;
            }
            else
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.SelectionColor = messageColor;
                box.AppendText(message + "\n");
                box.SelectionColor = box.ForeColor;
            }
        }
    }
}
