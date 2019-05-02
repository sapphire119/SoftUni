using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstRow = Console.ReadLine().Split(' ').ToArray();
            string[] secondRow = Console.ReadLine().Split(' ').ToArray();
            int maximum = Math.Max(firstRow.Length, secondRow.Length) - 1;
            int minimum = Math.Min(firstRow.Length, secondRow.Length) - 1;
            var startiterator = 0;
            var enditerator = 0;
            string[] largerArray = { };
            string[] smallerArray = { };
            if (firstRow.Length > secondRow.Length)
            {
                largerArray = firstRow;
                smallerArray = secondRow;
            }
            else
            {
                largerArray = secondRow;
                smallerArray = firstRow;
            }

            for (int i = 0; i <= minimum; i++) 
            {
                if (smallerArray[i]==largerArray[i])
                {
                    startiterator++;
                }
            }
            
            for (int j = maximum; j >= 0 && minimum >= 0; j--, minimum--) 
            {
                if (largerArray[j] == smallerArray[minimum])
                {
                    enditerator++;
                    
                }
            }
            Console.WriteLine("{0}",Math.Max(startiterator,enditerator));


        }
    }
}
