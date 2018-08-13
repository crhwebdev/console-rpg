using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props
{
    public class Weapon : Item
    {

        Weapon(string name) : base(name) { }

        public int AttackRating { get; set; }


    }
}
