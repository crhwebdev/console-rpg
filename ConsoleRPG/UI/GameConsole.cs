﻿using System;
using System.Collections.Generic;
using ConsoleRPG.System;
using ConsoleRPG.Game;


namespace ConsoleRPG.UI
{
    public class GameConsole : TextConsole
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
        
        public void WriteDisplayTextLine(string line)
        {
            _console.WriteLine(line);
        }

        public override void WriteDisplayTextLine(DisplayTextLine line)
        {                                            
            //Console.ForegroundColor = line.Color;                    
            _console.WriteLine(line.Text);
            //Console.ResetColor();            
        }

        public override string GetUserInput()
        {
            _console.Write("What is your command, Master?");
            return _console.ReadLine();
        }
     
    }
}
