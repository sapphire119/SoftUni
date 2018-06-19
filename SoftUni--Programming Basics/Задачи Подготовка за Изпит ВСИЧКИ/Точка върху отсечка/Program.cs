using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Точка_върху_отсечка
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int point = int.Parse(Console.ReadLine());
            int max ,min;
            max = min = 0;
            max = Math.Max(first, second);
            min = Math.Min(first, second);
            int number1, number2;
            number1 = max-point;
            number2 = min-point;
            int total = 0;
            total = Math.Min(Math.Abs(number1), Math.Abs(number2));

            if (point>=min &&point <=max)
            {
                Console.WriteLine("in\n{0}",Math.Abs(total));
            }
            else
            {
                Console.WriteLine("out\n{0}", Math.Abs(total));
            }
        }
    }
}
