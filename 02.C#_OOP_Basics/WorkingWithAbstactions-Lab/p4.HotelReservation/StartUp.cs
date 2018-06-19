namespace p4.HotelReservation
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            var pricePerDay = decimal.Parse(inputLine[0]);
            var numberOfDays = long.Parse(inputLine[1]);
            var season = Enum.Parse<SeasonType>(inputLine[2]);

            var priceCalcuator = new PriceCalculator(pricePerDay, numberOfDays, season);
            if (inputLine.Length == 4)
            {
                priceCalcuator.Discount = Enum.Parse<DiscountType>(inputLine[3]);
            }

            Console.WriteLine($"{priceCalcuator.CalculateTotalPrice():F2}");
        }
    }
}
