using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.System
{
    public class DisplayTextLine
    {
        public string Text { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.Black;

        public DisplayTextLine(string text)
        {
            Text = text;
        }

        public DisplayTextLine(string text, ConsoleColor color)
        {
            Text = text;
            Color = color;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
