using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Суми_от_3_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            var number1 = int.Parse(Console.ReadLine());
            var number2 = int.Parse(Console.ReadLine());
            var number3 = int.Parse(Console.ReadLine());

            int max, min;
            max = min = 0;
            int middle = 0;
            max = Math.Max(number1, Math.Max(number2, number3));
            min = Math.Min(number1, Math.Min(number2, number3));
            var sum = 0;
            sum = number1 + number2 + number3;

            middle = sum - max - min;
            if ((min+middle)==max)
            {
                Console.WriteLine("{0} + {1} = {2}", min, middle, max);
            }
            else
            {
                Console.WriteLine("No");
            }



        }
    }
}
