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
                        
        public void Update()
        {
            if(_displayBuffer != null)
            {
                foreach (DisplayTextLine line in _displayBuffer)
                {
                    _console.WriteLine(line.Text);
                }

                ClearDisplay();
            }
            
        }

        public void SetDisplay(DisplayText contents)
        {
            _displayBuffer = contents;
        }

        public void SetDisplay(string contents)
        {
            _displayBuffer = new DisplayText(contents);
        }

        public void ClearDisplay()
        {
            _displayBuffer = null;
        }

        public string GetUserInput(string cursor)
        {
            _console.Write(cursor);
            return _console.ReadLine();
            
            
        }
     
    }
}
