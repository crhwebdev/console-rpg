using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

public enum ErrorTextStrings { NoAttackTarget };
public enum CommandTextStrings { AttackExecutedOnTarget, AttackFailTargetNotFound };

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
                default:
                    return new DisplayText("No Such String");
            }
        }

    }
}
