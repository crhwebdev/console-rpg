﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props.Interfaces
{
    /// <summary>
    /// A enum for equipment slots
    /// </summary>
    public enum EquipmentSlots { Head, Body, Hands, Feet, MainWeapon, SecondaryWeapon };


    /// <summary>
    /// An interface of equipable objects in the game
    /// </summary>
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
