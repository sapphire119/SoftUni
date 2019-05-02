namespace _04._Hit_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var targets = new List<Person>();

            var targetInfoIndex = int.Parse(Console.ReadLine());

            string targetInput;
            while ((targetInput = Console.ReadLine()) != "end transmissions") 
            {
                var personKvp = targetInput.Split('=').ToArray();
                var infoArgs = personKvp[1].Split(';');

                var person = new Person()
                {
                    Name = personKvp[0],
                    InfoDictionary = new Dictionary<string, string>()
                };

                foreach (var item in infoArgs)
                {
                    var args = item.Split(':');

                    var key = args[0];
                    var value = args[1];
                    if (!person.InfoDictionary.ContainsKey(key))
                    {
                        person.InfoDictionary[key] = string.Empty;
                    }
                    person.InfoDictionary[key] = value;
                }

                if (!targets.Any(p => p.Name == person.Name))
                {
                    targets.Add(person);
                }
                else
                {
                    var currentPerson = targets.Find(p => p.Name == person.Name);
                    foreach (var kvp in person.InfoDictionary)
                    {
                        var key = kvp.Key;
                        var value = kvp.Value;
                        if (!currentPerson.InfoDictionary.ContainsKey(key))
                        {
                            currentPerson.InfoDictionary[key] = string.Empty;
                        }
                        currentPerson.InfoDictionary[key] = value;
                    }
                }
            }

            var killCommand = Console.ReadLine();
            var killName = killCommand.Split().Where(s => !string.IsNullOrWhiteSpace(s)).Skip(1).ToArray();
            var personToKill = targets.Find(p => p.Name == killName[0]);

            var infoIndex = 0;
            Console.WriteLine($"Info on {personToKill.Name}:");

            foreach (var kvp in personToKill.InfoDictionary.OrderBy(k => k.Key))
            {
                var key = kvp.Key;
                var value = kvp.Value;
                infoIndex += (key.Length + value.Length);
                Console.WriteLine($"---{key}: {value}");
            }

            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public Dictionary<string, string> InfoDictionary { get; set; }
        }
    }
}
