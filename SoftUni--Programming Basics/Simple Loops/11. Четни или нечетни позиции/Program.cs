using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Четни_или_нечетни_позиции
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            double oddsum, evensum;
            double oddmax, evenmax;
            double oddmin, evenmin;

            oddsum = evensum = 0;
            oddmin = evenmin = double.MaxValue;
            oddmax = evenmax = double.MinValue;
            
            if (numbers == 0)
                Console.WriteLine("OddSum=0, OddMin=no, OddMax=no, EvenSum=0, EvenMin=No, EvenMax=No");

            for (int i = 1; i <= numbers; i++)
            {

                double k = double.Parse(Console.ReadLine());

                if (numbers <= 1)
                {
                    Console.WriteLine("OddSum={0}, OddMin={0}, OddMax={0}, EvenSum=0, EvenMin=No, EvenMax=No",k);
                }

                if (i % 2 == 0)
                {
                    evensum += k;

                    if (evenmax < k)
                        evenmax = k;

                    if (evenmin > k)
                        evenmin = k;
                }

                else
                {
                    oddsum += k;
                    if (oddmax < k)
                        oddmax = k;
                    
                    if (oddmin > k)
                        oddmin = k;
                    
                }
            }
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}",
                               oddsum, oddmin, oddmax, evensum, evenmin, evenmax);

        }
    }
}
