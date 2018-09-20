using ConsoleRPG.Game.Props.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props
{
    public class Armor : Item, IEquipable
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC CONSTRUCTOR                          
        ////////////////////////////////////////////////////////////////////////////////////////

        public Armor(string name, int defenseBonus = 0) : base(name)
        {
            
            EquipableSlot = EquipmentSlots.Body; //for now, we set slot to MainWeapon.
            DefenseBonus = defenseBonus;
            AttackBonus = 0;
            AttackPowerBonus = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC PROPS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        public EquipmentSlots EquipableSlot { get; set; }
        public int AttackBonus { get; set; }
        public int DefenseBonus { get; set; }
        public int AttackPowerBonus { get; set; }
    }
}
