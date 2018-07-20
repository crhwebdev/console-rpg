using ConsoleRPG.Game.Actions;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using ConsoleRPG.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game
{
    public static class CommandInterpreter
    {
        public static void Interpret(string commandPhrase, GameEngine gameEngine)
        {
            var gameConsole = gameEngine.GameConsole;
            var player = gameEngine.Player;
            var room = gameEngine.Room;

            if (commandPhrase == "quit")
            {
                gameConsole.WriteDisplayTextLine(new DisplayTextLine("Stopping..."));
                gameEngine.Stop();
            }
            else if (commandPhrase == "look")
            {
                var look = new Look(player);

                gameConsole.WriteDisplayText(look.Do());
            }
            else if (commandPhrase == "move")
            {
                var move = new Move(player, room);
                gameConsole.WriteDisplayText(move.Do());
            }
            else if (commandPhrase == "say hello")
            {
                var say = new Say(player, "hello");

                gameConsole.WriteDisplayText(say.Do());
            }
            else
            {
                gameConsole.WriteDisplayTextLine(new DisplayTextLine("Say what?"));
            }
        }
    }
}
