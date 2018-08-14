using ConsoleRPG.Game.Props.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props
{
    public class Weapon : Item, IEquipable
    {

        public Weapon(string name) : base(name)
        {
            //for now, we set slot to MainWeapon.
            EquipableSlot = EquipmentSlots.MainWeapon;
            
        }

        public EquipmentSlots EquipableSlot { get; set; }
        public int AttackRating { get; set; }
    }
}
