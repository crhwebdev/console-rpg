using ConsoleRPG.System;
using ConsoleRPG.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPGTests.Mocks
{
    class MockGameConsole : TextConsole
    {
        public string Out { get; private set; }
            
        public override void Update(DisplayTextLine line)
        {            
            Out = line.Text;            
        }

    }
}
