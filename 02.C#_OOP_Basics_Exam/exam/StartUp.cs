using System;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public class StartUp
    {
        // DO NOT rename this file's namespace or class name.
        // However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
        public static void Main(string[] args)
        {
            DungeonMaster dungeonMaster = new DungeonMaster();
            string command;
            while (!string.IsNullOrWhiteSpace(command = Console.ReadLine()))
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = commandArgs[0];

                try
                {
                    switch (currentCommand)
                    {
                        case "JoinParty": Console.WriteLine(dungeonMaster.JoinParty(commandArgs.Skip(1).ToArray())); ; break;
                        case "AddItemToPool": Console.WriteLine(dungeonMaster.AddItemToPool(commandArgs.Skip(1).ToArray())); ; break;
                        case "PickUpItem": Console.WriteLine(dungeonMaster.PickUpItem(commandArgs.Skip(1).ToArray())); ; break;
                        case "UseItem": Console.WriteLine(dungeonMaster.UseItem(commandArgs.Skip(1).ToArray())); ; break;
                        case "UseItemOn": Console.WriteLine(dungeonMaster.UseItemOn(commandArgs.Skip(1).ToArray())); ; break;
                        case "GiveCharacterItem": Console.WriteLine(dungeonMaster.GiveCharacterItem(commandArgs.Skip(1).ToArray())); ; break;
                        case "GetStats": Console.WriteLine(dungeonMaster.GetStats()); ; break;
                        case "Attack": Console.WriteLine(dungeonMaster.Attack(commandArgs.Skip(1).ToArray())); break;
                        case "Heal": Console.WriteLine(dungeonMaster.Heal(commandArgs.Skip(1).ToArray())); break;
                        case "EndTurn": Console.WriteLine(dungeonMaster.EndTurn(new string[3])); break;
                        case "IsGameOver": Console.WriteLine(dungeonMaster.IsGameOver()); break;
                        default:
                            break;
                    }

                    if (dungeonMaster.IsGameOver())
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    if (e is ArgumentException)
                    {
                        string message = "Parameter Error: " + e.Message;
                        Console.WriteLine(message);
                    }
                    else if (e is InvalidOperationException)
                    {
                        string message = "Invalid Operation: " + e.Message;
                        Console.WriteLine(message);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Final stats:")
                .AppendLine($"{dungeonMaster.GetStats()}");

            var result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}