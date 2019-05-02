using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Exceptions;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            bool validateArmorRepairs = itemName == nameof(ArmorRepairKit);
            bool validateHealthPotion = itemName == nameof(HealthPotion);
            bool validatePoison = itemName == nameof(PoisonPotion);

            if (!validateArmorRepairs && !validateHealthPotion && !validatePoison)
            {
                throw new ArgumentException(string.Format(ProgramAllExceptionMessages.InvalidItemName, itemName));
                //throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }
            Item item = null;
            switch (itemName)
            {
                case nameof(ArmorRepairKit): item = new ArmorRepairKit(); break;
                case nameof(HealthPotion): item = new HealthPotion(); break;
                case nameof(PoisonPotion): item = new PoisonPotion(); break;
                default:
                    break;
            }

            return item;
        }
    }
}
