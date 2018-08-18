using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using ConsoleRPG.Game.Props.Interfaces;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actors
{
    public class Player : Actor
    {

        public Player(string name) : base(name) { }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC PROPS                          
        ////////////////////////////////////////////////////////////////////////////////////////        

        public override Location Location { get; set; }

                
        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        ////////////////////////////////////////////////////////////////////////////////////////        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClauseString"></param>
        /// <returns></returns>
        public override DisplayText Drop(string commandClauseString)
        {
            
            if (commandClauseString == "")
            {
                return new DisplayText("There is nothing to drop!");
            }

            var item = Util.GetItemMatchInInventory(this, commandClauseString);

            if (item != null)
            {
                Location.Items.Add(item);
                item.Location = Location;
                Inventory.Remove(item);
                                
                return new DisplayText(Name + " drops the " + item.Name);
            }
            else
            {
                item = Util.GetEquipSlotWithMatch(this, commandClauseString);
                if(item != null)
                {
                    return new DisplayText("You cannot drop an equiped item!");
                }
            }

            return new DisplayText("You don't have that item!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClauseString"></param>
        /// <returns></returns>
        public override DisplayText Equip(string commandClauseString)
        {            
             if(commandClauseString == "")
            {
                return new DisplayText("There is nothing to equip!");
            }

            var item = Util.GetItemMatchInInventory(this, commandClauseString);

            if(item != null)
            {
                if(item is IEquipable)
                {
                    var equipableItem = item as IEquipable;
                    switch (equipableItem.EquipableSlot)
                    {
                        case EquipmentSlots.Head:
                            EquipSlotHead = item;
                            Inventory.Remove(item);
                            break;
                        case EquipmentSlots.Body:
                            EquipSlotBody = item;
                            Inventory.Remove(item);
                            break;
                        case EquipmentSlots.Hands:
                            EquipSlotHands = item;
                            Inventory.Remove(item);
                            break;
                        case EquipmentSlots.Feet:
                            EquipSlotFeet = item;
                            Inventory.Remove(item);
                            break;
                        case EquipmentSlots.MainWeapon:
                            EquipSlotMainWeapon = item as Weapon;
                            Inventory.Remove(item);
                            break;                        
                        default:                            
                            return new DisplayText("You cannot equip that!");                           
                    }
                    
                    AddItemBonusesToStats(equipableItem);

                    return new DisplayText(Name + " equips the " + item.Name);
                }
                else
                {                    
                    return new DisplayText("You cannot equip that!");
                }                                
            }
            
            return new DisplayText("That does not exist in your inventory!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClauseString"></param>
        /// <returns></returns>
        public override DisplayText Get(string commandClauseString)
        {            
            if (commandClauseString == "")
            {
                return new DisplayText("There is nothing to get!");
            }

            var item = Util.GetItemMatchInLocation(this.Location, commandClauseString);

            if (item != null)
            {
                Inventory.Add(item);
                item.Location = null;
                Location.Items.Remove(item);                                
                return new DisplayText(Name + " gets the " + item.Name);
            }

            return new DisplayText("You cannot get that!");            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClauseString"></param>
        /// <returns></returns>        
        public override DisplayText Look(string commandClauseString)
        {
            var displayText = new DisplayText();

            var viewed = Util.GetViewableMatchInLocation(Location, commandClauseString);

            if (viewed == null)
            {
                return new DisplayText("I don't understand.");
                
            }
            
            if (viewed is Location)
            {
                displayText.Add(Name + " looks around...");
            }
            else
            {
                displayText.Add(Name + " looks at " + viewed.Name);
            }

            displayText.Add(viewed.Viewed(this));

            return displayText;                                                
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClauseString"></param>
        /// <returns></returns>
        public override DisplayText Move(string commandClauseString)
        {
            var displayText = new DisplayText();

            if(commandClauseString == "")
            {
                return new DisplayText(Name + " cannot move there!");
            }

            var destination = Util.GetExitMatchInLocation(this.Location, commandClauseString);

            if (destination == null)
            {
                return new DisplayText(Name + " cannot move there!");
            }

            if (IsHostile)
            {
                displayText.Add("You cannot move while in combat!");
            }
            else
            {
                displayText.Add(Name + " moves...");
                displayText.Add(destination.Enter(this));
            }
            
            return displayText;
        }

        public override DisplayText Say(string commandClauseString)
        {
            return new DisplayText(Name + " says: '" + commandClauseString + "'");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DisplayText ShowInventory()
        {
            var inventoryDisplayText = new DisplayText();
            var inventoryDisplayTextLine = new DisplayTextLine();  

            if(Inventory.Count < 1)
            {
                inventoryDisplayTextLine.Add("You have nothing in your pack, Master.");
            }
            else if(Inventory.Count == 1)
            {
                inventoryDisplayTextLine.Add("Master, you have: " + Inventory[0].Name + ".");
            }
            else
            {
                inventoryDisplayTextLine.Add("Your Inventory, Master: ");

                var index = 0;

                foreach (var item in Inventory)
                {
                    if (index == Inventory.Count - 1)
                    {
                        inventoryDisplayTextLine.Add(item.Name + ".");
                    }
                    else
                    {
                        inventoryDisplayTextLine.Add(item.Name + ", ");
                    }

                    index++;
                }
            }

            inventoryDisplayText.Add(inventoryDisplayTextLine);

            //now show equiped items
            inventoryDisplayText.Add("Your equiped items: (head) " + (EquipSlotHead != null ? EquipSlotHead.Name : "Empty") + ", " +
                "(main weapon) " + (EquipSlotMainWeapon != null ? EquipSlotMainWeapon.Name : "Empty") + ", " +                
                "(body) " + (EquipSlotBody != null ? EquipSlotBody.Name : "Empty") + ", " +
                "(hands) " + (EquipSlotHands != null ? EquipSlotHands.Name : "Empty") + ", " +
                "(feet) " + (EquipSlotFeet != null ? EquipSlotFeet.Name : "Empty"));
            
            return inventoryDisplayText;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClauseString"></param>
        /// <returns></returns>
        public override DisplayText Unequip(string commandClauseString)
        {
            var unequipDisplayText = new DisplayText();
            if (commandClauseString == "")
            {
                return new DisplayText("There is nothing to unequip!");
            }

            //search for item in equipment slots
            var item = Util.GetEquipSlotWithMatch(this, commandClauseString);
                                    
            if (item != null)
            {
                // For now we equip everything to and from Weapon slot - 
                // TODO add slot property equipable items that can be tested for to see where it goes
                Inventory.Add(item);
                var equipableItem = item as IEquipable;

                switch (equipableItem.EquipableSlot)
                {
                    case EquipmentSlots.Head:
                        EquipSlotHead = null;                        
                        break;
                    case EquipmentSlots.Body:
                        EquipSlotBody = null;                        
                        break;
                    case EquipmentSlots.Hands:
                        EquipSlotHands = null;                        
                        break;
                    case EquipmentSlots.Feet:
                        EquipSlotFeet = null;                        
                        break;
                    case EquipmentSlots.MainWeapon:
                        EquipSlotMainWeapon = null;                        
                        break;
                    default:
                        throw new Exception("Equiped item has no EquipableSlot");
                }

                RemoveItemBonusesFromStats(equipableItem);
                
                unequipDisplayText.Add(Name + " unequips the " + item.Name);
                return unequipDisplayText;
            }

            unequipDisplayText.Add("That is not equiped!");

            return unequipDisplayText;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PRIVATE METHODS                          
        ////////////////////////////////////////////////////////////////////////////////////////
        private void AddItemBonusesToStats(IEquipable item)
        {            
            Defense += item.DefenseBonus;                        
            Attack += item.AttackBonus;            
        }

        private void RemoveItemBonusesFromStats(IEquipable item)
        {                        
            Defense -= item.DefenseBonus;
            Attack -= item.AttackBonus;                        
        }

    }
}
