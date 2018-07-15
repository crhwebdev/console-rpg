using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.System
{
    public class ConsoleWrapper : IConsole
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
            return Console.ReadLine();
        }
    }
}
