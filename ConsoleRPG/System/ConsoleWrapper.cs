using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.System
{
    public class ConsoleWrapper : IConsole
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        /// <summary>
        /// Wrapper for Console.Write
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Wrapper for Console.WriteLine
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Wrapper for Console.Readline
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
