using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Abstracts.Contracts;
using DungeonsAndCodeWizards.Abstracts.Enums;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            :base(name, 50, 25, 40, new Backpack(), faction)
        {
            this.BaseHealth = 50;
            this.BaseArmor = 25;
            this.AbilityPoints = 40;
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            GeneralException.IsCharacterAlive(this);
            GeneralException.IsCharacterAlive(character);
            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }
            var newHealth = character.Health + this.AbilityPoints;
            character.SetHealth(newHealth);
            //character.Health += this.AbilityPoints;
        }
    }
}
