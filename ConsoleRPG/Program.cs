using ConsoleRPG.Game;
using ConsoleRPG.UI;
using System;

namespace ConsoleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            var game =  GameEngine.Instance();
            //Start Game
            game.Start();
        
            
        }
    }
}
