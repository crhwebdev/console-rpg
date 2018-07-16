using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    interface IAction
    {   
        string Display { get; set; }

        void Do();
    }
}
