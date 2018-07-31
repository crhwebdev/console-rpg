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
            var viewItem = new Item(itemName);
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
            var viewItem = new Item(itemName);
            location.Items.Add(viewItem);

            Assert.Null(Util.GetItemMatchInLocation(location, "Wrong Thing"));
            Assert.Equal(itemName, Util.GetItemMatchInLocation(location, itemName).Name);
            Assert.Equal(itemName, Util.GetItemMatchInLocation(location, itemName.ToLower()).Name);
        }

        [Fact]
        public void GetExitMatchInLocationReturnsCorrectMatch()
        {
            Assert.True(false);
        }
    }
}
