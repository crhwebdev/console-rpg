using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.System
{
    /// <summary>
    /// Encapsulates a line of text from the GameEngine class sent to the GameConsole class
    /// </summary>
    public class DisplayTextLine
    {
        public string Text { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
       
        public DisplayTextLine()
        {
            Text = "";
        }

        /// <summary>
        /// Creates an object that wraps the text and can be accessed either by converting
        /// object ToString
        /// Or by accessing public Text property
        /// </summary>
        /// <param name="text"></param>
        /// 
        public DisplayTextLine(string text)
        {
            Text = text;
        }
        /// <summary>
        ///Creates an object that wraps the text and can be accessed either by converting
        /// object ToString
        /// Or by accessing public Text property
        /// Also sets a Color property that can be used to set Console Line color
        /// </summary>
        /// <param name="text">line's text</param>
        /// <param name="color">line's console color using ConsoleColor</param>
        public DisplayTextLine(string text, ConsoleColor color)
        {
            Text = text;
            Color = color;
        }


        public void Add(string text)
        {
            Text += text;
        }

        public override string ToString()
        {
            return Text;            
        }
    }
}
