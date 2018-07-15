using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Command
{
    interface ICommand
    {
        string Name { get; set; }
        Dictionary<string, bool> Aliases { get; set; }

        void Do();
    }
}
