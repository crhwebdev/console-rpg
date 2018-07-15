using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Command
{
    interface ICommand
    {        
        void Do(string subject);
    }
}
