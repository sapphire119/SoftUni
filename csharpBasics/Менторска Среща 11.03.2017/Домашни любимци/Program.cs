using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашни_любимци
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int LeftFood = int.Parse(Console.ReadLine());
            var FoodForDog = double.Parse(Console.ReadLine());
            var FoodCat = double.Parse(Console.ReadLine());
            var FoodTurtleGrams = double.Parse(Console.ReadLine());

            var sumDog = FoodForDog * days;
            var sumCat = FoodCat * days;
            var sumTurtle = (FoodTurtleGrams * days) / 1000;
            var SumTotal = sumCat + sumDog + sumTurtle;

            if (SumTotal<=LeftFood)
            {
                
                Console.WriteLine("{0} kilos of food left.",
                    Math.Floor(LeftFood-SumTotal));
            }
            else
            {
                Console.WriteLine("{0} more kilos of food are needed.",
                    Math.Ceiling(SumTotal-LeftFood));
            }
            

        }
    }
}
