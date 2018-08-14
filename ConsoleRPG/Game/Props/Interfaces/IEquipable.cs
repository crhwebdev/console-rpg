using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props.Interfaces
{
    public enum EquipmentSlots { Head, Body, Hands, Feet, MainWeapon, SecondaryWeapon };

    public interface IEquipable
    {
        EquipmentSlots EquipableSlot { get; set; }
    }
}
