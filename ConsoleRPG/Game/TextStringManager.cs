using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

public enum ErrorTextStrings { NoAttackTarget, NoDropTarget, NoDropEquipedItem, NoSuchDropItem, NoEquipTarget, EquipNotEquipable, ItemNotInInventory, NoGetTarget, InvalidGetTarget };
public enum CommandTextStrings { AttackExecutedOnTarget, AttackFailTargetNotFound, DropItem, EquipItem, GetItem };

namespace ConsoleRPG.Game
{
    public static class TextStringManager
    {
        public static DisplayText GetErrorTextString(ErrorTextStrings text)
        {
            switch (text)
            {
                case ErrorTextStrings.NoAttackTarget:
                    return new DisplayText("There is nothing to attack!");
                case ErrorTextStrings.NoDropTarget:
                    return new DisplayText("There is nothing to drop!");
                case ErrorTextStrings.NoDropEquipedItem:
                    return new DisplayText("You cannot drop an equiped item!");
                case ErrorTextStrings.NoSuchDropItem:
                    return new DisplayText("You don't have that item!");
                case ErrorTextStrings.NoEquipTarget:
                    return new DisplayText("There is nothing to equip!");
                case ErrorTextStrings.EquipNotEquipable:
                    return new DisplayText("You cannot equip that!");
                case ErrorTextStrings.ItemNotInInventory:
                    return new DisplayText("That does not exist in your inventory!");
                case ErrorTextStrings.NoGetTarget:
                    return new DisplayText("There is nothing to get!");
                case ErrorTextStrings.InvalidGetTarget:
                    return new DisplayText("You cannot get that!");
                default:                    
                    return new DisplayText("No Such String");
            }
        }

        public static DisplayText GetCommandTextString(CommandTextStrings text, Actor actor, string targetName = "")
        {
            switch (text)
            {
                case CommandTextStrings.AttackExecutedOnTarget:
                    return new DisplayText(actor.Name + " attacks " + targetName + "!");
                case CommandTextStrings.AttackFailTargetNotFound:
                    return new DisplayText(actor.Name + " cannot attack that!");
                case CommandTextStrings.DropItem:
                    return new DisplayText(actor.Name + " drops the " + targetName);
                case CommandTextStrings.EquipItem:
                    return new DisplayText(actor.Name + " equips the " + targetName);
                case CommandTextStrings.GetItem:
                    return new DisplayText(actor.Name + " gets the " + targetName);
                default:
                    return new DisplayText("No Such String");
            }
        }

    }
}
