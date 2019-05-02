using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Exceptions;

namespace DungeonsAndCodeWizards.Items
{
    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit()
            : base(10)
        {
        }

        public override void AffectCharacter(Character character)
        {
            GeneralException.IsCharacterAlive(character);
            character.SetArmorToBaseArmor();
            //character.Armor = character.BaseArmor;
        }
    }
}
