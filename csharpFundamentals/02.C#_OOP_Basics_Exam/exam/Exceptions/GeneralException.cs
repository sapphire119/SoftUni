using DungeonsAndCodeWizards.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Exceptions
{
    public static class GeneralException
    {
        public static void IsCharacterAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
