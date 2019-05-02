using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] itemPairs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string,decimal>>();

            decimal goldAmount = 0;
            decimal gemsAmount = 0;
            decimal cashAmount = 0;

            for (int index = 0; index < itemPairs.Length; index += 2)
            {
                string itemName = itemPairs[index];
                decimal quantity = decimal.Parse(itemPairs[index + 1]);

                string itemType = GetItemType(itemName);

                if (CheckConstraint(bagCapacity, bag, quantity, itemType))
                    continue;

                if (itemType == "Gem")
                {
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (quantity > bag["Gold"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (bag[itemType].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if (itemType == "Cash")
                {
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (quantity > bag["Gem"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (bag[itemType].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
               

                if (!bag.ContainsKey(itemType))
                {
                    bag[itemType] = new Dictionary<string, decimal>();
                }

                if (!bag[itemType].ContainsKey(itemName))
                {
                    bag[itemType][itemName] = 0;
                }

                bag[itemType][itemName] += quantity;

                switch (itemType)
                {
                    case "Gold":goldAmount += quantity;break;
                    case "Gem":gemsAmount += quantity;break;
                    case "Cash":cashAmount += quantity;break;
                    default:
                        break;
                }
            }

            foreach (var itemTypeNameQuantity in bag)
            {
                var itemType = itemTypeNameQuantity.Key;
                var itemNameQuantity = itemTypeNameQuantity.Value;

                Console.WriteLine($"<{itemType}> ${itemNameQuantity.Values.Sum()}");

                foreach (var itemNameAndQuantity in itemNameQuantity.OrderByDescending(name => name.Key).ThenBy(quantity => quantity.Value))
                {
                    var itemName = itemNameAndQuantity.Key;
                    var itemQuantity = itemNameAndQuantity.Value;

                    Console.WriteLine($"##{itemName} - {itemQuantity}");
                }
            }
        }

        private static bool CheckConstraint(
            decimal bagCapacity, Dictionary<string, Dictionary<string,decimal>> bag, decimal quantity, string itemType)
        {
            bool isBagEmpty = itemType == string.Empty;
            bool isBagFull = bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity;
            return isBagFull || isBagEmpty;
        }

        private static string GetItemType(string itemName)
        {
            if (itemName.Length == 3)
            {
                return "Cash";
            }
            else if (itemName.ToLower().EndsWith("gem"))
            {
                return "Gem";
            }
            else if (itemName.ToLower() == "gold")
            {
                return "Gold";
            }

            return string.Empty;
        }
    }
}