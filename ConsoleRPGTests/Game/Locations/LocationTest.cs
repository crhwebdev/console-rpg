using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
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
            Assert.Equal(_player.GetPersonalPronoun() + " enters " + _areaDescription, areaEnterResult);
        }

        [Fact]
        public void AreaViewMethodReturnsAppropriateText()
        {
            var areaViewResult = _location.Viewed(_player).ToString();

            Assert.Equal(_player.GetPersonalPronoun() + " sees " + _areaDescription, areaViewResult);
        }

       
    }
}
