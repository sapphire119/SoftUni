using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sumLeft = 0;
            var sumRight = 0;
            var index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                for (int k = 0; k < i; k++)
                {
                    sumLeft += array[k];
                }
                for (int p = i+1; p < array.Length; p++)
                {
                    sumRight += array[p];
                }
                if (sumLeft==sumRight)
                {
                    index = i;
                }
                sumLeft = sumRight = 0;
            }
            if (index == -1) 
            {
                Console.WriteLine("no");
            }
            else
            {
                Console.WriteLine(index);
            }
        }
    }
}
