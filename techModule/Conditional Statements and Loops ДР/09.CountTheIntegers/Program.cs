using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CountTheIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = 0;
            bool input = int.TryParse(Console.ReadLine(), out result);
            var iterator = 0.0;
            while (input == true)
            {
                iterator++;
                input = int.TryParse(Console.ReadLine(), out result);
            }
            Console.WriteLine(iterator);

        }        
    }
}
