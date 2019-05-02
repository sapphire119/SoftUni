namespace p07.FoodShortage
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var citizens = new List<Citizen>();
            var rebels = new List<Rebel>();

            var linesCount = int.Parse(Console.ReadLine());

            for (int count = 0; count < linesCount; count++)
            {
                var personArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (personArgs.Length)
                {
                    case 4:CreateCitizen(citizens, personArgs, rebels);break;
                    case 3:CreateRebel(rebels, personArgs, citizens);break;
                    default:
                        break;
                }
            }

            string buyerName;
            while ((buyerName = Console.ReadLine()) != "End")
            {
                BuyFood(buyerName, citizens, rebels);
            }

            var totalFoodBought = citizens.Sum(c => c.BoughtFood) + rebels.Sum(r => r.BoughtFood);
            Console.WriteLine(totalFoodBought);
        }

        private static void BuyFood(string buyerName, List<Citizen> citizens, List<Rebel> rebels)
        {
            var existingCitizenBuyer = citizens.Find(c => c.Name == buyerName);
            if (existingCitizenBuyer != null)
            {
                existingCitizenBuyer.BuyFood();
                return;
            }

            var existingRebelBuyer = rebels.Find(r => r.Name == buyerName);
            if (existingRebelBuyer != null)
            {
                existingRebelBuyer.BuyFood();
                return;
            }
        }

        private static void CreateRebel(List<Rebel> rebels, string[] personArgs, List<Citizen> citizens)
        {
            try
            {
                var rebelName = personArgs[0];
                var rebelAge = int.Parse(personArgs[1]);
                var rebelGroup = personArgs[2];

                var existingCitizen = citizens.Find(c => c.Name == rebelName);
                if (existingCitizen != null)
                {
                    return;
                }

                var existingRebel = rebels.Find(r => r.Name == rebelName);
                if (existingRebel == null)
                {
                    existingRebel = new Rebel(rebelName, rebelAge, rebelGroup);
                    rebels.Add(existingRebel);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private static void CreateCitizen(List<Citizen> citizens, string[] personArgs, List<Rebel> rebels)
        {
            try
            {
                var citizenName = personArgs[0];
                var citizenAge = int.Parse(personArgs[1]);
                var citizenId = personArgs[2];
                var citizenBirthDate = personArgs[3];

                var existingRebel = rebels.Find(r => r.Name == citizenName);
                if (existingRebel != null)
                {
                    return;
                }

                var existingCitizen = citizens.Find(c => c.Name == citizenName);
                if (existingCitizen == null)
                {
                    existingCitizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthDate);
                    citizens.Add(existingCitizen);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
