using ConsoleRPG.Game.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game
{
    class TestDungeon : Level
    {
        public override List<Location> Locations { get; set; }
        
        public TestDungeon()
        {
            var location = new Area("The Chamber")
            {
                Description = "a dark dank chamber full of soft whispering voices... there is a small ornate door in the north wall."
            };
            var location2 = new Area("The Antechamber")
            {
                Description = "a small, brightly lit room with a small ornate door leading to the south."
            };

            location.ExitNorth = location2;
            location2.ExitSouth = location;

            Locations.Add(location);
            Locations.Add(location2);
        }
    }
}
