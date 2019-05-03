using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Четна_или_нечетна_сума
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiChisla = int.Parse(Console.ReadLine());
            int sumNechetni = 0;
            int SumChetni = 0;
            int total;
            int diffrence;
            for (int i = 1; i <= broiChisla; i++)
            {

                int k = int.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                     sumNechetni += k;
                }
                else if (i % 2 == 0)
                {
                    SumChetni += k;
                }

            }
            if (sumNechetni==SumChetni)
            {
                total = SumChetni = sumNechetni;
                Console.WriteLine("Yes");
                Console.WriteLine("Sum ={0}", total);
            }
            else
            {
                diffrence = Math.Abs(sumNechetni - SumChetni);
                Console.WriteLine("No");
                Console.WriteLine("Diff={0}",diffrence);
            }
        }
    }
}
