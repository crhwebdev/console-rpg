using ConsoleRPG.Game.Props.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props
{
    public class Weapon : Item, IEquipable
    {

        public Weapon(string name) : base(name) { }

        public EquipmentSlots EquipableSlot { get; set; }
        public int AttackRating { get; set; }
    }
}
