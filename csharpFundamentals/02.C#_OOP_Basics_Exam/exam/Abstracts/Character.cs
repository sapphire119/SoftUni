using DungeonsAndCodeWizards.Abstracts.Enums;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Abstracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;

        protected Character()
        {
            this.RestHealMultiplier = 0.2;
            this.IsAlive = true;
        }

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
            : this()
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
        }

        public virtual double RestHealMultiplier { get; private set; }

        public bool IsAlive { get; set; }

        public Faction Faction
        {
            get
            {
                return this.faction;
            }
            private set
            {
                this.faction = value;
            }
        }


        public Bag Bag
        {
            get
            {
                return this.bag;
            }
            private set
            {
                this.bag = value;
            }
        }


        public double AbilityPoints
        {
            get
            {
                return this.abilityPoints;
            }
            protected set
            {
                this.abilityPoints = value;
            }
        }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            protected set
            {
                if (value > this.BaseArmor)
                {
                    value = this.BaseArmor;
                }
                if (value < 0)
                {
                    value = 0;
                }
                this.armor = value;
            }
        }

        public double BaseArmor
        {
            get
            {
                return this.baseArmor;
            }
            protected set
            {
                this.baseArmor = value;
            }
        }

        public double Health
        {
            get
            {
                return this.health;
            }
            protected set
            {
                if (value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }
                if (value < 0)
                {
                    value = 0;
                }
                this.health = value;
            }
        }

        public double BaseHealth
        {
            get
            {
                return this.baseHealth;
            }
            protected set
            {
                this.baseHealth = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public void TakeDamage(double hitPoints)
        {
            GeneralException.IsCharacterAlive(this);

            var armorDiff = this.Armor - hitPoints;
            if (armorDiff >= 0)
            {
                this.Armor = armorDiff;
                return;
            }
            else
            {
                this.Armor = 0;
            }
            var restOfHitPoints = Math.Abs(armorDiff);
            this.Health -= restOfHitPoints;
            if (this.Health == 0.0)
            {
                this.IsAlive = false;
            }
        }

        public void Rest()
        {
            GeneralException.IsCharacterAlive(this);

            double healAmount = (this.BaseHealth * this.RestHealMultiplier);
            this.Health += healAmount;
        }

        public void UseItemOn(Item item, Character character)
        {
            GeneralException.IsCharacterAlive(this);
            GeneralException.IsCharacterAlive(character);
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            //    item.AffectCharacter(this);
            //    item.AffectCharacter(character);
            GeneralException.IsCharacterAlive(this);
            GeneralException.IsCharacterAlive(character);
            character.ReceiveItem(item);
            //TODO
        }

        public void ReceiveItem(Item item)
        {
            //item.AffectCharacter(this);
            GeneralException.IsCharacterAlive(this);
            this.Bag.AddItem(item);
            //TODo
            //if (this.IsAlive)
            //{
            //    //TODO
            //}
        }

        public void SetArmorToBaseArmor()
        {
            this.Armor = this.BaseArmor;
        }

        public void SetHealth(double value)
        {
            this.Health = value;
        }
    }
}
