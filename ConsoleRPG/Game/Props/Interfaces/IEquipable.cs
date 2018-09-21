using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props.Interfaces
{
    public enum EquipmentSlots { Head, Body, Hands, Feet, MainWeapon, SecondaryWeapon };

    public interface IEquipable
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC PROPS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        EquipmentSlots EquipableSlot { get; set; }
        int AttackBonus { get; set; }
        int DefenseBonus { get; set; }
        int AttackPowerBonus { get; set; }
    }
}
