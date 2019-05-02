using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long priceOfJewels = inputData[0];
            long priceOfGold = inputData[1];
            var input = string.Empty;
            var firstPartOfInput = string.Empty;
            var secondPartOfInput = string.Empty;
            var arrayOfChars = new char[inputData.Length];
            long sumOfJewels = 0;
            long sumOfGold = 0;
            long totalEarnings = 0;
            long totalExpenses = 0;
            var iterator = 0;
            while (input != "Jail Time")
            {
                iterator++;
                if (iterator != 1) 
                {
                    firstPartOfInput = input.Split().First();
                    arrayOfChars = firstPartOfInput.ToCharArray();
                    for (int i = 0; i < arrayOfChars.Length; i++)
                    {
                        if (arrayOfChars[i] == '%')
                        {
                            sumOfJewels += priceOfJewels;
                        }
                        else if (arrayOfChars[i] == '$')
                        {
                            sumOfGold += priceOfGold;
                        }
                    }
                    secondPartOfInput = input.Split().Last();
                    totalExpenses += long.Parse(secondPartOfInput);
                    totalEarnings += (sumOfJewels + sumOfGold);
                    sumOfGold = sumOfJewels = 0; 
                }
                input = Console.ReadLine();
            }
            if (totalEarnings>=totalExpenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {totalEarnings-totalExpenses}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {totalExpenses-totalEarnings}.");
            }
        }
    }
}
