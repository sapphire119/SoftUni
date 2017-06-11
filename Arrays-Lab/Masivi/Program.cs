using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masivi
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var items = input.Split(' '); //или string[]

            int[] nums = Console.ReadLine().Split(new[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries).Select
                (int.Parse).ToArray();

            //int[] nums = Console.ReadLine().Split(' ').Select
            //(int.Parse).ToArray();

            //int[] nums = items.Select(int.Parse).ToArray();

            //var nums = new int[items.Length];
            //for (int i = 0; i < items.Length; i++)
            //{
            //    nums[i] = int.Parse(Console.ReadLine());
            //}
            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

        }
    }
}
