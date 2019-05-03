using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Умната_Лили
{
    class Program
    {
        static void Main(string[] args)
        {

            int years  = int.Parse(Console.ReadLine());
            double machine = double.Parse(Console.ReadLine());
            int cenatoy = int.Parse(Console.ReadLine());
            int igrachka = 0;
            int pari = 0;
            int krajba = 0;
            int total = 0;
            int sum = 0;
            for (int i = 1; i <= years; i++) 
            {
                if (i%2 !=0)
                {
                    igrachka += 1;
                }
                if (i%2==0)
                {
                    sum += 10;
                    pari += sum; 
                    krajba += 1;
                }
            }
            Console.WriteLine();
            total = pari + (igrachka * cenatoy) - krajba;
            if (total >= machine)
            {
                Console.WriteLine("Yes! {0:f2}", (total - machine));
            }
            else
            {
                Console.WriteLine("No! {0:f2}", Math.Abs(total - machine));
            }

        }
    }
}
