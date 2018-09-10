using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Say : Action
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //   CONSTRUCTOR                          
        ////////////////////////////////////////////////////////////////////////////////////////

        public Say(Actor actor, string text)
        {
            _actor = actor;
            _text = text;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PRIVATE FIELDS                          
        ////////////////////////////////////////////////////////////////////////////////////////

        public string Display { get; set; }
        private Actor _actor;
        private string _text;


        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        /// <summary>
        /// Executes Say action, which calls 
        ///  Say method on Actor.
        /// </summary>
        /// <returns>DisplayText</returns>
        public override DisplayText Do()
        {
            var displayText = _actor.Say(_text);
            return displayText;
        }
    }
}
