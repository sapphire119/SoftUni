using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Редица_числа_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sum = 1;
            do
            {
                Console.WriteLine(sum);
                sum = 2 * sum + 1;

            } while (sum<=input);
        }
    }
}
