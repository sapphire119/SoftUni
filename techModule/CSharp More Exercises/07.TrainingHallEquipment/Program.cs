using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.TrainingHallEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var numbOfItems = int.Parse(Console.ReadLine());
            var subtotal = 0.0;
            var firstBudget = budget;
            for (int i = 1; i <= numbOfItems; i++)
            {
                var name = Console.ReadLine();
                var price = double.Parse(Console.ReadLine());
                var count = int.Parse(Console.ReadLine());
                subtotal += (price * count);
                budget -= (price * count);
                if (count ==1)
                {
                    Console.WriteLine($"Adding {count} {name} to cart.");
                }
                else
                {
                    Console.WriteLine($"Adding {count} {name}s to cart.");
                }
            }
            if (budget>=0)
            {
                Console.WriteLine($"Subtotal: ${subtotal:f2}");
                Console.WriteLine($"Money left: ${budget:f2}");
            }
            else
            {
                Console.WriteLine($"Subtotal: ${subtotal:f2}");
                Console.WriteLine($"Not enough. We need ${(subtotal-firstBudget):f2} more.");
            }

        }
    }
}
