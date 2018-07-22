using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game
{
    class TestDungeon : Level
    {
        public override List<Location> Locations { get; set; } = new List<Location>();
        public override Location StartingArea { get; set; } 

        public TestDungeon()
        {
            //declare NPCs
            var bob = new NPC("Bob")
            {
                Description = "a burly man in his mid 40s. He is smiling at you as if expecting you to say something."
            };

            //declare rooms
            var theChamber = new Area("The Chamber")
            {
                Description = "a dark dank chamber full of soft whispering voices... there is a small ornate door in the north wall.",              
            };

            bob.Location = theChamber;
            theChamber.Actors.Add(bob);

            var theAntechamber = new Area("The Antechamber")
            {
                Description = "a small, brightly lit room with a small ornate door leading to the south."
            };

            theChamber.ExitNorth = theAntechamber;
            theAntechamber.ExitSouth = theChamber;

            Locations.Add(theChamber);
            Locations.Add(theAntechamber);

            StartingArea = theChamber;
        }
    }
}
