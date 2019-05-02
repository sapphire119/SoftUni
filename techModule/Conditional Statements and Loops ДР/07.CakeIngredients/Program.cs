using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var iterator = 0.0;
            while (input != "Bake!")
            {
                iterator++;
                Console.WriteLine($"Adding ingredient {input}.");
                input = Console.ReadLine();
                
            }
            Console.WriteLine("Preparing cake with {0} ingredients.",iterator);
        }
    }
}
