using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BeverageLeveles
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var volume = int.Parse(Console.ReadLine());
            var energy = int.Parse(Console.ReadLine());
            var sugarC = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}ml {1}:\n{2}kcal, {3}g sugars", volume
                , name
                ,((volume * energy) / 100.0)
                ,((volume*sugarC)/100.0)
                );

        }
    }
}
