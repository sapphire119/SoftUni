using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сума_през_3_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            int sum1, sum2, sum3;
            sum1 = sum2 = sum3 = 0;
            int chislo1, chislo2, chislo3;
            chislo1 = chislo2 = chislo3 = 0;
            for (int i = 1; i <= input; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (i == 1 || (i > 3 && i - 3 == chislo1))
                {
                    chislo1 = i;
                    sum1 += number;
                }
                if (i == 2 || (i > 4 && i - 3 == chislo2))
                {
                    chislo2 = i;
                    sum2 += number;
                }
                if (i == 3 || (i > 5 && i - 3 == chislo3))
                {
                    chislo3 = i;
                    sum3 += number;
                }

            }
            Console.WriteLine("sum1 = {0}", sum1);
            Console.WriteLine("sum2 = {0}", sum2);
            Console.WriteLine("sum3 = {0}", sum3);
        }
    }
}
