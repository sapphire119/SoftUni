using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Abstracts.Contracts;
using DungeonsAndCodeWizards.Abstracts.Enums;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Exceptions;

namespace DungeonsAndCodeWizards.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, 100.0, 50.0, 40.0, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            GeneralException.IsCharacterAlive(this);
            GeneralException.IsCharacterAlive(character);
            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {character.Faction} faction!");
            }
            character.TakeDamage(this.AbilityPoints);
        }
    }
}
