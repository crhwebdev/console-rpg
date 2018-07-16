using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.UI
{
    public abstract class TextConsole
    {

        public abstract void WriteDisplayTextLine(DisplayTextLine line);

        public abstract void WriteDisplayText(DisplayText text);

        public virtual string GetUserInput()
        {
            return Console.ReadLine();
        }
        
    }
}
