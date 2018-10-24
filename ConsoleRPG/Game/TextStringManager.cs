using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

public enum ErrorTextStrings { NoAttackTarget, NoDropTarget, NoDropEquipedItem, NoSuchDropItem };
public enum CommandTextStrings { AttackExecutedOnTarget, AttackFailTargetNotFound, DropItem };

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
                default:
                    return new DisplayText("No Such String");
            }
        }

    }
}
