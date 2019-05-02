using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Choose_a_Drink
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            //var quantity = int.Parse(Console.ReadLine());
            
            switch (input)
            {
                case "Athlete": Console.WriteLine("Water");
                    //Console.WriteLine($"The {input} has to pay {(quantity*0.70):f2}.");
                    break;

                case "Businessman":
                case "Businesswoman":
                    Console.WriteLine("Coffee");
                   // Console.WriteLine($"The {input} has to pay {(quantity * 1.00):f2}.");
                    break;
                case "SoftUni Student": Console.WriteLine("Beer");
                    //Console.WriteLine($"The {input} has to pay {(quantity * 1.70):f2}.");
                    break;
                default:
                    Console.WriteLine("Tea");
                   // Console.WriteLine($"The {input} has to pay {(quantity * 1.20):f2}.");
                    break;
            }

        }
    }
}
