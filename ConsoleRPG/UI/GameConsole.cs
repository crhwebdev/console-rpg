using System;
using System.Collections.Generic;
using ConsoleRPG.System;
using ConsoleRPG.Game;


namespace ConsoleRPG.UI
{
    public class GameConsole : TextConsole
    {        
        private IConsole _console;
        
        public GameConsole()
        {
            _console = new ConsoleWrapper();
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
            Console.ResetColor();
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
