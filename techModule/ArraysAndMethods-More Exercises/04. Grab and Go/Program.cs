using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var number = long.Parse(Console.ReadLine());
            var index = -1;
            long sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (number == array[i])
                {
                    index = i;
                }
            }
            if (index == -1)
            {
                Console.WriteLine("No occurrences were found!");
                return;
            }
            for (int j = 0; j < index; j++)
            {
                sum += array[j];
            }
            Console.WriteLine(sum);
        }
    }
}
