using System;
using System.Collections.Generic;
using ConsoleRPG.System;
using ConsoleRPG.Game;


namespace ConsoleRPG.UI
{
    public class GameConsole
    {
        private DisplayText _displayBuffer = null;
        private IConsole _console;
        
        public GameConsole()
        {
            _console = new ConsoleWrapper();
        }

        public GameConsole(IConsole console)
        {
            _console = console;
        }
                        
        public void Update(DisplayTextLine line)
        {                                            
            //Console.ForegroundColor = line.Color;                    
            _console.WriteLine(line.Text);
            //Console.ResetColor();            
        }
        
        public string GetUserInput(string cursor)
        {
            _console.Write(cursor);
            return _console.ReadLine();
            
            
        }
     
    }
}
