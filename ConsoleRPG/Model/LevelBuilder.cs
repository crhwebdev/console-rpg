using ConsoleRPG.Game;
using ConsoleRPG.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Model
{
    public class LevelBuilder
    {
        private static LevelBuilder _instance;
        private LevelData _levelData;
        private Level _levelInstance;

        public static LevelBuilder Instance()
        {
            if(_instance == null)
            {
                _instance = new LevelBuilder();
            }

            return _instance;
        }

        public void CreateNewLevel(){}
        public void CreateNewLevel(string fileName){}
        public void AddPlayerToLevel(Player player){}
        public Level GetNewLevel()
        {
            return _levelInstance;
        }

        private void AddUnlinkedLocationsToLevel() { }
        private void LinkLocations() { }
        private void AddActorsToLevel() { }
        private void AddItemsToLevel() { }
        
    }

    //NOTE: These could be structs instead of classes
    public class LevelData
    {

    }

    public class LocationData
    {

    }

    public abstract class ActorData
    {

    }

    public abstract class PropData
    {

    }
}
