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
            Assert.True(false);
        }

        [Fact]
        public void GetItemMatchInLocationReturnsCorrectMatch()
        {
            Assert.True(false);
        }

        [Fact]
        public void GetExitMatchInLocationReturnsCorrectMatch()
        {
            Assert.True(false);
        }
    }
}
