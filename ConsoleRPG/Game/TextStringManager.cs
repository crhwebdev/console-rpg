using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

public enum ErrorTextStrings
{
    NoAttackTarget,
    NoDropTarget,
    NoDropEquipedItem,
    NoSuchDropItem,
    NoEquipTarget,
    EquipNotEquipable,
    ItemNotInInventory,
    NoGetTarget,
    InvalidGetTarget,
    InvalidLookTarget,
    CannotMoveInCombat,
    InvalidUnequipTarget,
    CannotUnequipTarget
};

public enum CommandTextStrings
{
    AttackExecutedOnTarget,
    AttackFailTargetNotFound,
    DropItem,
    EquipItem,
    GetItem,
    LookAt,
    LookAtLocation,
    CannotMoveToTarget,
    MoveToTargetLocation,
    InventoryEmpty,
    ShowInventory,
    UnequipItem,
    SaySomething
};

public enum GeneralTextStrings
{
    ActorEntersLocation,
    ActorViewsLocation,
    ActorIsHere
};

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
                case ErrorTextStrings.InvalidLookTarget:
                    return new DisplayText("There's nothing to look at!");
                case ErrorTextStrings.CannotMoveInCombat:
                    return new DisplayText("You cannot move while in combat!");
                case ErrorTextStrings.InvalidUnequipTarget:
                    return new DisplayText("There is nothing to unequip!");
                case ErrorTextStrings.CannotUnequipTarget:
                    return new DisplayText("That is not equiped!");
                default:                    
                    return new DisplayText("No Such String");
            }
        }

        public static DisplayText GetCommandTextString(CommandTextStrings text, Actor actor, string targetText = "")
        {
            switch (text)
            {
                case CommandTextStrings.AttackExecutedOnTarget:
                    return new DisplayText(actor.Name + " attacks " + targetText + "!");
                case CommandTextStrings.AttackFailTargetNotFound:
                    return new DisplayText(actor.Name + " cannot attack that!");
                case CommandTextStrings.DropItem:
                    return new DisplayText(actor.Name + " drops the " + targetText);
                case CommandTextStrings.EquipItem:
                    return new DisplayText(actor.Name + " equips the " + targetText);
                case CommandTextStrings.GetItem:
                    return new DisplayText(actor.Name + " gets the " + targetText);
                case CommandTextStrings.LookAt:
                    return new DisplayText(actor.Name + " looks at " + targetText);
                case CommandTextStrings.LookAtLocation:
                    return new DisplayText(actor.Name + " looks around...");
                case CommandTextStrings.CannotMoveToTarget:
                    return new DisplayText(actor.Name + " cannot move there!");
                case CommandTextStrings.MoveToTargetLocation:
                    return new DisplayText(actor.Name + " moves...");
                case CommandTextStrings.InventoryEmpty:
                    return new DisplayText("You have nothing in your pack, Master.");
                case CommandTextStrings.ShowInventory:
                    return new DisplayText("Master, you have: ");
                case CommandTextStrings.UnequipItem:
                    return new DisplayText(actor.Name + " unequips the " + targetText);
                case CommandTextStrings.SaySomething:
                    return new DisplayText(actor.Name + " says: '" + targetText + "'");
                default:
                    return new DisplayText("No Such String");
            }
        }

        public static DisplayText GetGeneralTextString(GeneralTextStrings text, Actor actor, string targetText = "")
        {
            switch (text)
            {
                case GeneralTextStrings.ActorEntersLocation:
                    return new DisplayText(actor.GetPersonalPronoun() + " enters " + targetText);
                case GeneralTextStrings.ActorViewsLocation:
                    return new DisplayText(actor.GetPersonalPronoun() + " sees " + targetText);
                case GeneralTextStrings.ActorIsHere:
                    return new DisplayText(actor.Name + " is here");
                default:
                    return new DisplayText("No Such String");
            }
        }
    }
}
