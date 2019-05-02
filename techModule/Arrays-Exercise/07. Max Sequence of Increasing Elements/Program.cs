using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var newArray = new int[array.Length];
            array.CopyTo(newArray, 0);
            var lengthOfSequence = 0;
            var bestSequence = 0;
            var index = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i + 1] > newArray[i])  
                {
                    lengthOfSequence++;
                }
                else
                {
                    lengthOfSequence = 0;
                }
                if (bestSequence < lengthOfSequence)
                {
                    bestSequence = lengthOfSequence;
                    index = i + 1 - lengthOfSequence;
                }
            }

            for (int k = 0; k <= bestSequence; k++,index++) 
            {
                Console.Write(array[index] + " ");
            }

        }
    }
}
