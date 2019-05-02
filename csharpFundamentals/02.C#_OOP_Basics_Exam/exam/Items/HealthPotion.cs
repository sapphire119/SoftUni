using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion()
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            GeneralException.IsCharacterAlive(character);
            var newHp = character.Health + 20;
            character.SetHealth(newHp);
            //character.Health += 20;
        }
    }
}
