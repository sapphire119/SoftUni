using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masivi_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] reversed = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                reversed[i] = nums[nums.Length - i - 1];
            }
            Console.WriteLine(string.Join(" ",reversed));
        }
    }
}
