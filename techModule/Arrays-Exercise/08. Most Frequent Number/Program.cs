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
            var array = Console.ReadLine().Split().Select(ushort.Parse).ToArray();
            var newArray = new ushort[array.Length];
            array.CopyTo(newArray, 0);
            var numberRepeated = 0;
            var bestSequence = 0;
            var number = 0;
            var numbersUsed = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int p = 0; p < array.Length; p++)
                {
                    if (array[i] == newArray[p])
                    {
                        numberRepeated++;
                    }
                    if (bestSequence < numberRepeated)
                    {
                        bestSequence = numberRepeated;
                        number = array[i];
                    }

                }
                numberRepeated = 0;
                numbersUsed[i] += array[i];
            }
            Console.Write(number + " ");

        }
    }
}
