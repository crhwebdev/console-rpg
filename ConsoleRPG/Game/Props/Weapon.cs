using ConsoleRPG.Game.Props.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props
{
    public class Weapon : Item, IEquipable
    {

        public Weapon(string name, int attackBonus = 0) : base(name)
        {
            //for now, we set slot to MainWeapon.
            EquipableSlot = EquipmentSlots.MainWeapon;
            AttackBonus = attackBonus;
            
        }

        public EquipmentSlots EquipableSlot { get; set; }
        public int AttackBonus { get; set; }
        public int DefenseBonus { get; set; }
    }
}
