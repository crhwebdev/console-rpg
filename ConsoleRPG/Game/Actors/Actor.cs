using ConsoleRPG.Game.Interfaces;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actors
{
    public enum  Sexes { Neuter, Male, Female };

    public abstract class Actor : IViewable
    {        
        public virtual string Name { get; set; }
        public virtual Sexes Sex { get; set; }
        public virtual string Description { get; set; }
        public virtual Location Location { get; set; }

        //primary attribute that determines ability to absorb blows
        public virtual int Defense { get; set; }
        //primary skill that determines chance to hit a target and avoid being  hit
        public virtual int Attack { get; set; }
        //effects damage and is modified by Strength and Weapon AttackPowerBonus
        public virtual int AttackPower { get; set; }  
        //how much damage target can take
        public virtual int Hardiness { get; set; }
        //modifies AttackPower
        public virtual int Strength { get; set; }

        //Actor Inventory
        public virtual List<Item> Inventory { get; set; }

        //Actor Equipment slots
        public virtual Item EquipSlotMainWeapon { get; set; }
        public virtual Item EquipSlotHead { get; set; }
        public virtual Item EquipSlotHands { get; set; }       
        public virtual Item EquipSlotBody { get; set; }
        public virtual Item EquipSlotFeet { get; set; }        

        //Actor State
        public virtual bool IsHostile { get; set; }


        public Actor(string name)
        {
            Name = name;
            Description = "an entity";
            Sex = Sexes.Neuter;
            Inventory = new List<Item>();
            IsHostile = false;
        }

        //Has various methods that correspond to actions that can be executed with him as the reciever               
        public virtual DisplayText Drop(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText Equip(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText Get(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText ShowInventory() { throw new NotImplementedException(); }
        public virtual DisplayText Move(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText Look(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText Say(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText Unequip(string commandClauseString) { throw new NotImplementedException(); }

        //IViewable implementation
        public virtual DisplayText Viewed(Actor viewer)
        {
            return new DisplayText(viewer.GetPersonalPronoun() + " sees " + Description);
        }

        //utility methods
        public virtual string GetPersonalPronoun()
        {
            if(Sex == Sexes.Neuter)
            {
                return "It";
            }
            else if(Sex == Sexes.Male)
            {
                return "He";
            }
            else if(Sex == Sexes.Female)
            {
                return "She";
            }

            return "It";
        }

    }
}
