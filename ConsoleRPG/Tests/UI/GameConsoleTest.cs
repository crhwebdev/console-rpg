using Xunit;
using System;
using System.IO;
using System.Collections.Generic;
using ConsoleRPG.UI;
using ConsoleRPG.Tests.Mocks;
using ConsoleRPG.System;

namespace ConsoleRPG.Tests.UI
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
            _gameConsole = new GameConsole(new MockGameConsole());
            _out = new StringWriter();
            _standardOut = new StreamWriter(Console.OpenStandardOutput());
        }

        private void ClearTest()
        {            
            _standardOut.AutoFlush = true;
            Console.SetOut(_standardOut);
        }

        [Fact]
        public void UpdateWritesStringToConsole()
        {
            Console.SetOut(_out);            
            _gameConsole.SetDisplay("Hello World!");
            _gameConsole.Update();
            Assert.Equal("Hello World!\r\n", _out.ToString());
            ClearTest();
        }

        [Fact]
        public void UpdateWritesListToConsole()
        {
            Console.SetOut(_out);
            _gameConsole.SetDisplay(new DisplayText(new List<DisplayTextLine> { new DisplayTextLine("Hello World!"), new DisplayTextLine("I am Here!") }));
            _gameConsole.Update();
            Assert.Equal("Hello World!\r\nI am Here!\r\n", _out.ToString());
            ClearTest();
        }

        [Fact]
        public void GetUserInputWritesCursorToConsole()
        {
            Console.SetOut(_out);
            var cursor = "What is your command?";
            var message = _gameConsole.GetUserInput(cursor);
            Assert.Equal(cursor, _out.ToString());
            ClearTest();
        }

        [Fact]
        public void GetUserInputReturnsString()
        {
            var message = _gameConsole.GetUserInput("");
            Assert.IsType<string>(message);
        }
        
    }
  
}
