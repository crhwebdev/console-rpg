using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actors
{
    ////////////////////////////////////////////////////////////////////////////////////////
    //   CONSTRUCTOR
    //////////////////////////////////////////////////////////////////////////////////////// 

    public class NPC : Actor
    {
        public NPC(string name) : base(name) {}

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        ////////////////////////////////////////////////////////////////////////////////////////        

        /// <summary>
        /// Handles Attack command for NPC
        /// </summary>
        /// <param name="commandClauseString"></param>
        /// <returns>DisplayText of results of attack</returns>
        public override DisplayText Attack(string commandClauseString)
        {
            return new DisplayText(Name + " attacks!");
        }
    }

  
}
