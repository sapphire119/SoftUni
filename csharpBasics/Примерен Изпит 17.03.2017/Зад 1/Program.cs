using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //17.01.2016 (1 и 3та)
            //26.02.2016 Programing Fundamentals  зад 1.
            //18.02.2016 Letter Combinations
            
            int cakes = int.Parse(Console.ReadLine());
            double NeededFlour = double.Parse(Console.ReadLine());
            int Flouravailable = int.Parse(Console.ReadLine());
            double Truffles = int.Parse(Console.ReadLine());
            double PriceOfTruffle = int.Parse(Console.ReadLine());

            
            var cakesTotal = Flouravailable / NeededFlour;
            
            

            double TruffleCost = Truffles * PriceOfTruffle;

            if (cakesTotal >= cakes)
            {
                double cakePrice = (TruffleCost * 1.25) / cakes;
                Console.WriteLine("All products available, price of a cake: {0:f2}",cakePrice);
            }
            else
            {
                double totalFlour = cakes * NeededFlour;
                double Kgneeded = totalFlour - Flouravailable;
                Console.WriteLine("Can make only {0} cakes, need {1:f2} kg more flour",
                    Math.Truncate(cakesTotal)
                    , Kgneeded);
            }

        }
    }
}
