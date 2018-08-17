using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game
{
    public class CombatManager
    {
        private static CombatManager _instance = null;
        private GameEngine _game = null;

        protected CombatManager(GameEngine game)
        {
            _game = game;
        }

        //This method returns either the existing Instance of CombatManager or creates a new one
        // a reference to the GameEngine must be passed in.
        public static CombatManager Instance(GameEngine game)
        {
            if (_instance == null)
            {
                _instance = new CombatManager(game);
            }

            return _instance;
        }

        //This returns an reference to the existing CombatManager instance without requiring 
        //that a reference to an existing GameEngine be passed in. If it is called before their
        //is an instance, it will return an error.
        public static CombatManager Instance()
        {
            if(_instance == null)
            {
                throw new Exception("CombatManager not initialzied");
            }

            return _instance;
        }
    }
}
