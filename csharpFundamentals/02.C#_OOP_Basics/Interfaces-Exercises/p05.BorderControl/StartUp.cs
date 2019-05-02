namespace p05.BorderControl
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var entries = new List<IEntity>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs != null && command.Length != 0)
                {
                    var id = commandArgs.Last();
                    entries.Add(new Citizen(id)); 
                }
            }

            var lastDigits = Console.ReadLine();

            foreach (var citizen in entries)
            {
                if (citizen.Id.EndsWith(lastDigits))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
    }
}
