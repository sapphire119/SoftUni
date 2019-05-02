namespace p13.FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split();
              
            var personOfInterest = new Person();
            if (inputLine.Length == 2)
            {
                personOfInterest.FirstName = inputLine[0];
                personOfInterest.LastName = inputLine[1];
            }
            else
            {
                personOfInterest.Birthday = inputLine[0];
            }


            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var predecessorInfo = Console.ReadLine().Split('-').Select(s => s.Trim()).ToArray();



            }

        }
    }
}
