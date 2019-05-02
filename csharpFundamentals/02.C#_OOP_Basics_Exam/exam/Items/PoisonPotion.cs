using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Exceptions;

namespace DungeonsAndCodeWizards.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion()
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            GeneralException.IsCharacterAlive(character);
            var newHp = character.Health - 20;
            character.SetHealth(newHp);
            //character.Health -= 20;
            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
