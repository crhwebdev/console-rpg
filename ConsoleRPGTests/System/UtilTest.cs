using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Linq;
using Xunit;

namespace ConsoleRPGTests.System
{
    public class UtilTest
    {
        [Fact]
        public void GetViewableMatchInLocationReturnsCorrectMatch()
        {
            var locationName = "Testing Area";
            var itemName = "Test Item";
            var npcName = "Test Dude";

            var location = new Location(locationName);
            var viewItem = new Weapon(itemName);
            var viewNPC = new NPC(npcName);

            location.Items.Add(viewItem);
            location.Actors.Add(viewNPC);

            Assert.Equal(locationName, Util.GetViewableMatchInLocation(location, "").Name);
            Assert.Equal(itemName, Util.GetViewableMatchInLocation(location, itemName).Name);
            Assert.Equal(itemName, Util.GetViewableMatchInLocation(location, itemName.ToLower()).Name);
            Assert.Equal(npcName, Util.GetViewableMatchInLocation(location, npcName).Name);
            Assert.Equal(npcName, Util.GetViewableMatchInLocation(location, npcName.ToLower()).Name);

        }

        [Fact]
        public void GetItemMatchInInventoryReturnsCorrectMatch()
        {
            var player = new Player("Test Dude");
            var itemName = "Thing";
            var item = new Weapon(itemName);
            player.Inventory.Add(item);

            Assert.Null(Util.GetItemMatchInInventory(player, "wrong stuff"));
            Assert.Equal(itemName, Util.GetItemMatchInInventory(player, itemName).Name);
            Assert.Equal(itemName, Util.GetItemMatchInInventory(player, itemName.ToLower()).Name);

        }

        [Fact]
        public void GetActorMatchInLocationnReturnsCorrectMatch()
        {
            var locationName = "Testing Area";
            var npcName = "Test Dude";

            var location = new Location(locationName);
            var viewNPC = new NPC(npcName);
            location.Actors.Add(viewNPC);

            Assert.Null(Util.GetActorMatchInLocation(location, "Wrong Dude"));
            Assert.Equal(npcName, Util.GetActorMatchInLocation(location, npcName).Name);
            Assert.Equal(npcName, Util.GetActorMatchInLocation(location, npcName.ToLower()).Name);
            
        }

        [Fact]
        public void GetItemMatchInLocationReturnsCorrectMatch()
        {
            var locationName = "Testing Area";
            var itemName = "Test Item";

            var location = new Location(locationName);
            var viewItem = new Weapon(itemName);
            location.Items.Add(viewItem);

            Assert.Null(Util.GetItemMatchInLocation(location, "Wrong Thing"));
            Assert.Equal(itemName, Util.GetItemMatchInLocation(location, itemName).Name);
            Assert.Equal(itemName, Util.GetItemMatchInLocation(location, itemName.ToLower()).Name);
        }

        [Fact]
        public void GetExitMatchInLocationReturnsCorrectMatch()
        {
            var locationName = "Testing Area";
            var otherLocationName = "Another Place";
            var exitName = "north";
            var wrongExitName = "bob";

            var location = new Location(locationName);
            var otherLocation = new Location(otherLocationName);

            location.ExitNorth = otherLocation;

            Assert.Null(Util.GetExitMatchInLocation(location, wrongExitName));
            Assert.Equal(otherLocationName, Util.GetExitMatchInLocation(location, exitName).Name);
        }
    }
}
