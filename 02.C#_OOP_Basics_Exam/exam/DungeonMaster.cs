using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Abstracts.Enums;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Exceptions;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        private List<Character> characters;
        private List<Item> items;
        private int lastSurvivorRounds;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {

            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.characters = new List<Character>();
            this.items = new List<Item>();
            this.lastSurvivorRounds = 0;
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];

            string characterType = args[1];

            string name = args[2];

            Character character = this.characterFactory.CreateCharacter(faction, characterType, name);
            this.characters.Add(character);

            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);
            items.Add(item);
            return $"{item.GetType().Name} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            var existingCharacter = characters.Find(c => c.Name == characterName);
            if (existingCharacter == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CharacterNotFound, characterName));
                //throw new ArgumentException($"Character {characterName} not found!");
            }
            if (!this.items.Any())
            {
                throw new InvalidOperationException(string.Format(ProgramAllExceptionMessages.NoItemsLeftInPool));
                //throw new InvalidOperationException("No items left in pool!");
            }

            var lastItem = this.items.Last();
            this.items.RemoveAt(this.items.Count - 1); // Moje da e grshno
            existingCharacter.ReceiveItem(lastItem);

            return $"{characterName} picked up {lastItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var existingCharacter = characters.Find(c => c.Name == characterName);
            if (existingCharacter == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CharacterNotFound, characterName));
                //throw new ArgumentException($"Character {characterName} not found!");
            }

            var existingItem = existingCharacter.Bag.GetItem(itemName);
            existingItem.AffectCharacter(existingCharacter);

            return $"{existingCharacter.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            var existingGiver = this.characters.Find(c => c.Name == giverName);
            if (existingGiver == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CharacterNotFound, giverName));
                //throw new ArgumentException($"Character {giverName} not found!");
            }

            var existingReciever = this.characters.Find(c => c.Name == receiverName);
            if (existingReciever == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CharacterNotFound, receiverName));
                //throw new ArgumentException($"Character {receiverName} not found!");
            }

            var itemToUse = existingGiver.Bag.GetItem(itemName);

            existingGiver.UseItemOn(itemToUse, existingReciever);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            var existingGiver = this.characters.Find(c => c.Name == giverName);
            if (existingGiver == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CharacterNotFound, giverName));
                //throw new ArgumentException($"Character {giverName} not found!");
            }

            var existingReciever = this.characters.Find(c => c.Name == receiverName);
            if (existingReciever == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CharacterNotFound, receiverName));
                //throw new ArgumentException($"Character {receiverName} not found!");
            }

            var givingItem = existingGiver.Bag.GetItem(itemName);
            existingGiver.GiveCharacterItem(givingItem, existingReciever);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in this.characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                var characterStatus = character.IsAlive ? "Alive" : "Dead";

                //{name} - HP: {health}/{baseHealth}, AP: {armor}/{baseArmor}, Status: {Alive/Dead}
                sb.AppendLine(
                    $"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {characterStatus}");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string receiverName = args[1];

            var existingAttacker = this.characters.Find(c => c.Name == attackerName);
            if (existingAttacker == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CharacterNotFound, attackerName));
                //throw new ArgumentException($"Character {attackerName} not found!");
            }

            var existingReciever = this.characters.Find(c => c.Name == receiverName);
            if (existingReciever == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CharacterNotFound, receiverName));
                //throw new ArgumentException($"Character {receiverName} not found!");
            }

            var attacker = existingAttacker as Warrior;
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CannotAttack, attackerName));
                //throw new ArgumentException($"{existingAttacker.Name} cannot attack!");
            }

            sb.Append($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! ");
             
            attacker.Attack(existingReciever);

            sb.AppendLine($"{receiverName} has {existingReciever.Health}/{existingReciever.BaseHealth} HP and {existingReciever.Armor}/{existingReciever.BaseArmor} AP left!");

            if (!existingReciever.IsAlive)
            {
                sb.AppendLine($"{existingReciever.Name} is dead!");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public string Heal(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string healerName = args[0];
            string healingReceiverName = args[1];

            var existinHealer = this.characters.Find(c => c.Name == healerName);
            if (existinHealer == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CharacterNotFound, healerName));
                //throw new ArgumentException($"Character {healerName} not found!");
            }

            var existingTarget = this.characters.Find(c => c.Name == healingReceiverName);
            if (existingTarget == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CharacterNotFound, healingReceiverName));
                //throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            var healer = existinHealer as Cleric;
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.CannotHeal, healerName));
                //throw new ArgumentException($"{healerName} cannot heal!");
            }

            healer.Heal(existingTarget);

            sb.AppendLine($"{healer.Name} heals {existingTarget.Name} for {healer.AbilityPoints}! {existingTarget.Name} has {existingTarget.Health} health now!");

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int numberOfAliveCharacters = 0;

            for (int count = 0; count < this.characters.Count; count++)
            {
                if (this.characters[count].IsAlive)
                {
                    numberOfAliveCharacters++;

                    var character = this.characters[count];
                    var oldHp = character.Health;
                    character.Rest();
                    sb.AppendLine($"{character.Name} rests ({oldHp} => {character.Health})");
                }
            }

            if (numberOfAliveCharacters == 0 || numberOfAliveCharacters == 1)
            {
                this.lastSurvivorRounds++;
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public bool IsGameOver()
        {
            var survivors = this.characters.Where(c => c.IsAlive).ToList();
            if (survivors.Count == 0 || survivors.Count == 1)
            {
                if (lastSurvivorRounds > 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}