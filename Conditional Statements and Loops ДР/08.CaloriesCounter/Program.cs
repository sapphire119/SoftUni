using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var sum = 0.0;
            for (int i = 1; i <= input; i++)
            {
                var add = Console.ReadLine().ToLower();
                if (add == "cheese")
                {
                    sum += 500;
                }
                if (add == "tomato sauce")
                {
                    sum += 150;
                }
                if (add == "salami")
                {
                    sum += 600;
                }
                if (add == "pepper")
                {
                    sum += 50;
                }
            }
            Console.WriteLine($"Total calories: {sum}");
        }
    }
}
