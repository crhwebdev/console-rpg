using Xunit;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using ConsoleRPG.UI;
using ConsoleRPGTests.Mocks;
using ConsoleRPG.System;

namespace ConsoleRPGTests.UI
{
    public class GameConsoleTest
    {
        //Console displays text passed as a message
        //Console gets user input 
        //Console Update shows current Display and then clears the Display. If Display is empty, it shows nothing
        private GameConsole _gameConsole;
        private StringWriter _out;
        private StreamWriter _standardOut;

        public GameConsoleTest()
        {
            _gameConsole = new GameConsole(new MockConsole());
            _out = new StringWriter();
            _standardOut = new StreamWriter(Console.OpenStandardOutput());
        }

        private void ClearTest()
        {
            _standardOut.AutoFlush = true;
            Console.SetOut(_standardOut);
        }


     

        [Fact]
        public void WritesDisplayTextLineToConsole()
        {
            Console.SetOut(_out);            
            _gameConsole.WriteDisplayTextLine(new DisplayTextLine("Hello World!"));
            Assert.Equal("Hello World!\r\n", _out.ToString());
            ClearTest();
        }

        [Fact]
        public void WritesDisplayTextToConsole()
        {
            var displayText = new DisplayText(new List<DisplayTextLine>
            {
                new DisplayTextLine("Hello World!"),
                new DisplayTextLine("Bye World!")
            });
            Console.SetOut(_out);
            _gameConsole.WriteDisplayText(displayText);
            Assert.Equal("Hello World!\r\n\r\nBye World!\r\n\r\n", _out.ToString());
            ClearTest();
        }

        
        [Fact]
        public void GetUserInputReturnsString()
        {
            var message = _gameConsole.GetUserInput();
            Assert.IsType<string>(message);
        }

    }
}
