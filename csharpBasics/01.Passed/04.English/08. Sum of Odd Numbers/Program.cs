using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var current = 1;
            var sum = 0;
            while (input>0)
            {
                Console.WriteLine(current);
                sum += current;
                current = current + 2;
                input--;
                
            }
            Console.WriteLine($"Sum: {sum}");
            
        }
    }
}
