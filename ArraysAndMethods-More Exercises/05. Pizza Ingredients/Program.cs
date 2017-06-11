using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Pizza_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().ToArray();
            var number = int.Parse(Console.ReadLine());
            var iteratorIngredients = 0;
            var ingredients = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length == number)
                {
                    iteratorIngredients++;
                    Console.WriteLine($"Adding {array[i]}.");
                    ingredients[i] += array[i];
                    if (iteratorIngredients >= 10)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"Made pizza with total of {iteratorIngredients} ingredients.");
            ingredients = ingredients.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            Console.WriteLine("The ingredients are: " + string.Join(", ",ingredients)+".");

        }
    }
}
