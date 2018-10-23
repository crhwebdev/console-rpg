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
        ////////////////////////////////////////////////////////////////////////////////////////
        //   CONSTRUCTOR
        //////////////////////////////////////////////////////////////////////////////////////// 
        
        public Actor(string name)
        {
            Name = name;
            Description = "an entity";
            Sex = Sexes.Neuter;
            Inventory = new List<Item>();
            IsHostile = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC PROPERTIES                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        public virtual string Name { get; set; }
        public virtual Sexes Sex { get; set; }
        public virtual string Description { get; set; }
        public virtual Location Location { get; set; }

        //primary attribute that determines ability to absorb blows
        public virtual int Defense { get; set; }
        //primary skill that determines chance to hit a target and avoid being  hit
        public virtual int AttackChance { get; set; }
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


        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        //Has various methods that correspond to actions that can be executed with him as the reciever               

        /// <summary>
        /// Handles Attack command for player
        /// </summary>
        /// <param name="commandClauseString"></param>
        /// <returns>DisplayText of results of attack</returns>
        public virtual DisplayText Attack(string commandClauseString)
        {
            if (commandClauseString == "")
            {
                return TextStringManager.GetErrorTextString(ErrorTextStrings.NoAttackTarget);
            }

            var target = Location.GetActorMatchInLocation(commandClauseString);

            if (target != null)
            {
                return TextStringManager.GetCommandTextString(CommandTextStrings.AttackExecutedOnTarget, this, target.Name);
            }

            return TextStringManager.GetCommandTextString(CommandTextStrings.AttackFailTargetNotFound, this);

        }

        public virtual DisplayText Drop(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText Equip(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText Get(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText ShowInventory() { throw new NotImplementedException(); }
        public virtual DisplayText Move(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText Look(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText Say(string commandClauseString) { throw new NotImplementedException(); }
        public virtual DisplayText Unequip(string commandClauseString) { throw new NotImplementedException(); }

        /// <summary>
        /// Returns DisplayText of Actors Description
        /// </summary>
        /// <param name="viewer">Actor that is using Look method on this object</param>
        /// <returns>DisplayText with Actors Description</returns>
        public virtual DisplayText Viewed(Actor viewer)
        {
            return new DisplayText(viewer.GetPersonalPronoun() + " sees " + Description);
        }

        /// <summary>
        /// Gets a PersonalPronoun based on Actors Sex property
        /// </summary>
        /// <returns>String value: It, He, She</returns>
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

        

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PROTECTED METHODS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        /// <summary>
        /// Roles nultiple "FUDGE" dice and returns total result
        /// </summary>
        /// <param name="numberOfDice">Number of dice to role</param>
        /// <returns>An int value representintg total of dice rolls</returns>
        protected int RollMultipleDice(int numberOfDice = 4)
        {
            var sum = 0;

            for (var i = 1; i <= numberOfDice; i++)
            {
                sum += RollSingleDie();
            }

            return sum;
        }

        /// <summary>
        /// Role a single "FUDGE" dice and returns result
        /// </summary>
        /// <returns>An int value from -1 to +1</returns>
        protected int RollSingleDie()
        {
            //generate random number between 1 and 6
            var random = new Random();
            var dieRoll = random.Next(1, 7);
            //translate random number to FUD dice results
            var dieResult = 0;
            if (dieRoll == 1 || dieRoll == 2)
            {
                dieResult = -1;
            }
            else if (dieRoll == 3 || dieRoll == 4)
            {
                dieResult = 0;
            }
            else if (dieRoll == 5 || dieRoll == 6)
            {
                dieResult = 1;
            }
            else
            {
                dieResult = 100;
            }

            return dieResult;
        }


        /// <summary>
        /// Get item in an equipmentslot or null if none equiped
        /// </summary>
        /// <param name="targetName">name of equipment slot</param>
        /// <returns>An Item that is equiped in slot</returns>
        protected Item GetEquipSlotWithMatch(string targetName)
        {

            //Go through all Equip slots
            if (EquipSlotMainWeapon != null && targetName.Equals(EquipSlotMainWeapon.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                return EquipSlotMainWeapon;
            }
            if (EquipSlotHead != null && targetName.Equals(EquipSlotHead.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                return EquipSlotHead;
            }
            if (EquipSlotHands != null && targetName.Equals(EquipSlotHands.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                return EquipSlotHands;
            }
            if (EquipSlotBody != null && targetName.Equals(EquipSlotBody.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                return EquipSlotBody;
            }
            if (EquipSlotFeet != null && targetName.Equals(EquipSlotFeet.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                return EquipSlotFeet;
            }

            return null;
        }

        /// <summary>
        /// Get an Item in Actor's Inventory if it matches targetName
        /// </summary>
        /// <param name="targetName">Name of item to match</param>
        /// <returns>An Item that matches targetName</returns>
        protected Item GetItemMatchInInventory(string targetName)
        {
            if (targetName == "")
            {
                return null;
            }

            foreach (var item in Inventory)
            {
                if (targetName.Equals(item.Name, StringComparison.CurrentCultureIgnoreCase) && item is Item)
                {
                    return item as Item;
                }
            }
            return null;
        }

    }
}
