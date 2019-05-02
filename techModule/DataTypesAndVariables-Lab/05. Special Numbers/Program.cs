using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            for (int num = 1; num <= input; num++)
            {
                var sum = 0;
                var current = num;
                while (current > 0)
                {
                    sum += current % 10;
                    current /= 10;
                }
                bool isNumberSpecial = (sum == 5 || sum == 7 || sum == 11);
                Console.WriteLine("{0} -> {1}", num, isNumberSpecial);
                
            }
        }
    }
}
