using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using System;
using System.Linq;
using Xunit;

namespace ConsoleRPGTests.Game.Locations
{
    public class AreaTest
    {
        private string _areaName;
        private string _areaDescription;
        private Area _area;
        private Player _player;

        public AreaTest()
        {
            _player = new Player("Testy Tess");
            _areaName = "Testing Ground";
            _areaDescription = "Test your mettle in the testing ground!";
            _area = new Area(_areaName)
            {
                Description = _areaDescription
            };
            
        }

        [Fact]
        public void CanInstantiateAreaWithAName()
        {            
            Assert.Equal(_areaName, _area.Name);
        }

        [Fact]
        public void AreaEnterMethodReturnsAppropriateTextAndSetsPlayerLocation()
        {
            var areaEnterResult = _area.Enter(_player).ToString();

            Assert.Equal(_player.Location, _area);
            Assert.Equal("You enter " + _areaDescription, areaEnterResult);
        }

        [Fact]
        public void AreaViewMethodReturnsAppropriateText()
        {
            var areaViewResult = _area.Viewed(_player).ToString();

            Assert.Equal("You see " + _areaDescription, areaViewResult);
        }

       
    }
}
