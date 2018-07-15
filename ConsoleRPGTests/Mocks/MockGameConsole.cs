using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.System;

namespace ConsoleRPGTests.Mocks
{
    public class MockGameConsole : IConsole
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public string ReadLine()
        {
            return "";
        }
    }
}
