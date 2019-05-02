namespace p06.BirthdayCelebrations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            var entries = new List<IEntity>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split();

                if (tokens[0].ToLower() == "robot")
                {
                    continue;
                }

                var lastToken = tokens.Last();
                DateTime? currentDate = GetValidDate(lastToken);
                if (currentDate == null)
                {
                    continue;
                }

                entries.Add(new Citizen(currentDate.Value.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
            }

            var yearToLookFor = Console.ReadLine();
            //int countOfPrintedItems = 0;
            for (int index = 0; index < entries.Count; index++)
            {
                if (entries[index].BirthDate.EndsWith(yearToLookFor))
                {
                    //countOfPrintedItems++;
                    Console.WriteLine($"{entries[index].BirthDate}");
                }
            }

            //if (countOfPrintedItems == 0)
            //{
            //    Console.WriteLine("<empty output>");
            //}
        }

        private static DateTime? GetValidDate(string lastToken)
        {
            var dateTokens = lastToken.Split('/');
            var dateTime = new DateTime();
            try
            {
                var year = int.Parse(dateTokens[2]);
                var month = int.Parse(dateTokens[1]);
                var day = int.Parse(dateTokens[0]);

                dateTime = new DateTime(year, month, day);
            }
            catch (Exception)
            {
                return null;
            }

            return dateTime;
        }
    }
}
