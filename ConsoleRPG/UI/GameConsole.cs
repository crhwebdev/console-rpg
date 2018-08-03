using System;
using System.Collections.Generic;
using ConsoleRPG.System;
using ConsoleRPG.Game;


namespace ConsoleRPG.UI
{
    

    public class GameConsole : TextConsole
    {        
        private IConsole _console;
        private const ConsoleColor DEFAULT_TEXT_COLOR = ConsoleColor.White;

        public GameConsole()
        {
            _console = new ConsoleWrapper();
            Console.ForegroundColor = DEFAULT_TEXT_COLOR;
        }

        public GameConsole(IConsole console)
        {
            _console = console;
        }
        
        public void WriteDisplayTextLine(string line)
        {
            _console.WriteLine(line);
        }

        public override void WriteDisplayTextLine(DisplayTextLine line)
        {
            Console.ForegroundColor = line.Color;
            _console.WriteLine(line.Text);
            Console.ForegroundColor = DEFAULT_TEXT_COLOR;
        }

        public override void WriteDisplayText(DisplayText text)
        {
            foreach(var line in text)
            {                
                WriteDisplayTextLine(line as DisplayTextLine);
                WriteDisplayTextLine("");
            }
        }

        public override string GetUserInput()
        {
            WriteDisplayTextLine("");
            _console.Write("What is your command, Master?");
            var text = _console.ReadLine();
            WriteDisplayTextLine("");
            return text;
        }
     
    }
}
