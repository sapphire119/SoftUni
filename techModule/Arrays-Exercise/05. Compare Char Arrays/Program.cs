using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstArray = Console.ReadLine().Split().Select(char.Parse).ToArray();
            var secondArray = Console.ReadLine().Split().Select(char.Parse).ToArray();
            var minimum = Math.Min(firstArray.Length, secondArray.Length);
            for (int i = 0; i < minimum; i++)
            {
                if (firstArray[i] < secondArray[i])
                {
                    Console.WriteLine(string.Join("", firstArray));
                    Console.WriteLine(string.Join("", secondArray));
                    return;
                }
                else if (firstArray[i]>secondArray[i])
                {
                    Console.WriteLine(string.Join("", secondArray));
                    Console.WriteLine(string.Join("", firstArray));
                    return;
                }
            }

            if (firstArray.Length > secondArray.Length)
            {
                Console.WriteLine(string.Join("", secondArray));
                Console.WriteLine(string.Join("", firstArray));
            }
            else if(firstArray.Length < secondArray.Length)
            {
                Console.WriteLine(string.Join("", firstArray));
                Console.WriteLine(string.Join("", secondArray));
            }
            else
            {
                Console.WriteLine(string.Join("", firstArray));
                Console.WriteLine(string.Join("",secondArray));
            }

            

        }
    }
}
