using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.System
{
    /// <summary>
    /// An interface for Console Objects that wrap standard System.Console
    /// </summary>
    public interface IConsole
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        ////////////////////////////////////////////////////////////////////////////////////////

        void Write(string text);

        void WriteLine(string text);

        string ReadLine();
    }
}
