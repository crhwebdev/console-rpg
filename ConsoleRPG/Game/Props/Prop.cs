using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Interfaces;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;

namespace ConsoleRPG.Game.Props
{
    public abstract class Prop : IViewable
    {

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC CONSTRUCTOR                          
        ////////////////////////////////////////////////////////////////////////////////////////

        public Prop(string name)
        {
            Name = name;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC PROPS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Location Location { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        /// <summary>
        /// Returns a DisplayText object with the text description of the Prop
        /// </summary>
        /// <param name="viewer">The actor object that is calling this method and to whcih a DisplayText object is returned</param>
        /// <returns>A DisplayText object</returns>
        public virtual DisplayText Viewed(Actor viewer)
        {
            return new DisplayText(Description);
        }
            
    }
}
