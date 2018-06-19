using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Abstracts.Enums;
using DungeonsAndCodeWizards.Characters;
using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Exceptions;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            var validateFaction = Enum.TryParse(faction, out Faction realFaction);
            if (!validateFaction)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.InvalidFaction, faction));
                //throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            bool warriorCheck = characterType == nameof(Warrior);
            bool clericCheck = characterType == nameof(Cleric);

            if (!warriorCheck && !clericCheck)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.InvalidCharacterType, characterType));
                //throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            Character character = null;
            switch (characterType)
            {
                case nameof(Warrior):
                    character = new Warrior(name, realFaction);
                    break;
                case nameof(Cleric):
                    character = new Cleric(name, realFaction);
                    break;
                default:
                    break;
            }

            return character;
        }
    }
}
