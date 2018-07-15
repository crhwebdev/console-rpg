using System;
using System.Collections.Generic;
using ConsoleRPG.System;
using ConsoleRPG.Game;


namespace ConsoleRPG.UI
{
    public class GameConsole
    {
        private List<string> _displayBuffer = null;
        private IConsole _console;
        
        public GameConsole()
        {
            _console = new ConsoleWrapper();
        }

        public GameConsole(IConsole console)
        {
            _console = console;
        }
                        
        public void Update()
        {
            if(_displayBuffer != null)
            {
                foreach (string line in _displayBuffer)
                {
                    _console.WriteLine(line);
                }

                ClearDisplay();
            }
            
        }

        public void SetDisplay(List<string> contents)
        {
            _displayBuffer = contents;
        }

        public void SetDisplay(string contents)
        {
            _displayBuffer = new List<string> { contents };
        }

        public void ClearDisplay()
        {
            _displayBuffer = null;
        }

        public Message GetUserInput(string cursor)
        {
            _console.Write(cursor);
            var input = _console.ReadLine();
            return new Message(input);
            
        }
     
    }
}
