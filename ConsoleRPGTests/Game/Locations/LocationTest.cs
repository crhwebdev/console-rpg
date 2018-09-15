using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using System;
using System.Linq;
using Xunit;

namespace ConsoleRPGTests.Game.Locations
{
    public class LocationTest
    {
        private string _areaName;
        private string _areaDescription;
        private Location _location;
        private Player _player;

        public LocationTest()
        {
            _player = new Player("Testy Tess");
            _areaName = "Testing Ground";
            _areaDescription = "Test your mettle in the testing ground!";
            _location = new Location(_areaName)
            {
                Description = _areaDescription
            };
            
        }

        [Fact]
        public void CanInstantiateAreaWithAName()
        {            
            Assert.Equal(_areaName, _location.Name);
        }

        [Fact]
        public void AreaEnterMethodReturnsAppropriateTextAndSetsPlayerLocation()
        {
            var areaEnterResult = _location.Enter(_player).ToString();

            Assert.Equal(_player.Location, _location);
            Assert.Equal(_areaName + "/r/n" + _player.GetPersonalPronoun() + " enters " + _areaDescription, areaEnterResult);
        }

        [Fact]
        public void AreaViewMethodReturnsAppropriateText()
        {
            var areaViewResult = _location.Viewed(_player).ToString();

            Assert.Equal(_player.GetPersonalPronoun() + " sees " + _areaDescription, areaViewResult);
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

            Assert.Null(location.GetExitMatchInLocation(wrongExitName));
            Assert.Equal(otherLocationName, location.GetExitMatchInLocation(exitName).Name);
        }

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

            Assert.Equal(locationName, location.GetViewableMatchInLocation("").Name);
            Assert.Equal(itemName, location.GetViewableMatchInLocation(itemName).Name);
            Assert.Equal(itemName, location.GetViewableMatchInLocation(itemName.ToLower()).Name);
            Assert.Equal(npcName, location.GetViewableMatchInLocation(npcName).Name);
            Assert.Equal(npcName, location.GetViewableMatchInLocation(npcName.ToLower()).Name);

        }

        [Fact]
        public void GetActorMatchInLocationnReturnsCorrectMatch()
        {
            var locationName = "Testing Area";
            var npcName = "Test Dude";

            var location = new Location(locationName);
            var viewNPC = new NPC(npcName);
            location.Actors.Add(viewNPC);

            Assert.Null(location.GetActorMatchInLocation("Wrong Dude"));
            Assert.Equal(npcName, location.GetActorMatchInLocation(npcName).Name);
            Assert.Equal(npcName, location.GetActorMatchInLocation(npcName.ToLower()).Name);

        }
    }
}
