using ConsoleRPG.Game.Props.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props
{
    public class Armor : Item, IEquipable
    {
        public Armor(string name, int defenseBonus = 0) : base(name)
        {
            //for now, we set slot to MainWeapon.
            EquipableSlot = EquipmentSlots.Body;
            DefenseBonus = defenseBonus;
            AttackBonus = 0;
        }

        public EquipmentSlots EquipableSlot { get; set; }
        public int AttackBonus { get; set; }
        public int DefenseBonus { get; set; }
    }
}
