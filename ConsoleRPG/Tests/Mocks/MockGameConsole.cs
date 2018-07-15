using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Tests.Mocks
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
