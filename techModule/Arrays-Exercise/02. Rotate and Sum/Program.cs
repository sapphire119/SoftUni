using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rotations = int.Parse(Console.ReadLine());
            var newArray = new int[array.Length];
            var sum = new int[array.Length];

            for (int i = 0; i < rotations; i++)
            {
                RotateArray(array, newArray, i);
                for (int k = 0; k < array.Length; k++)
                {
                    sum[k] += newArray[k];
                }
            }
            Console.WriteLine(string.Join(" ", sum));
        }

        private static void RotateArray(int[] array, int[] newArray,int rotations)
        {
            newArray[0] = array[array.Length - 1];
            for (int j = 1; j <= array.Length - 1; j++)
            {
                newArray[j] = array[j -1];
            }
            newArray.CopyTo(array,0);
        }
        
    }
}
