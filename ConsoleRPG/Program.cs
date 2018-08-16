using ConsoleRPG.Game;
using ConsoleRPG.System;
using ConsoleRPG.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleRPG
{
    class Program
    {                
        static void Main(string[] args)
        {
            var game = GameEngine.Instance();
            //Start Game
            game.Start();
        }
    }
}
