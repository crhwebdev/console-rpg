using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

public enum ErrorTextStrings { NoAttackTarget };

namespace ConsoleRPG.Game
{
    public static class TextStringManager
    {
        public static DisplayText GetErrorTextString(ErrorTextStrings type)
        {
            switch (type)
            {
                case ErrorTextStrings.NoAttackTarget:
                    return new DisplayText("There is nothing to attack!");                    
                default:
                    return new DisplayText("No Such String");
            }
        }

    }
}
