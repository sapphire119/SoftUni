using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_1.Зеленчукова_борса
{
    class Program
    {
        static void Main(string[] args)
        {

            double vegies = double.Parse(Console.ReadLine());
            double fruits = double.Parse(Console.ReadLine());

            int kgveg = int.Parse(Console.ReadLine());
            int kgfruit = int.Parse(Console.ReadLine());

            double sum1;
            double sum2;
            double total;

            //if (vegies >=0 && vegies<=1000 && fruits >= 0 && fruits <= 1000 &&
            //    kgveg >= 0 && kgveg <= 1000 && kgfruit >= 0 && kgfruit <= 1000)

                sum1 = vegies * kgveg;
                sum2 = fruits * kgfruit;
                total = (sum1 + sum2) / 1.94;
                Console.WriteLine(total);

            


        }
    }
}
