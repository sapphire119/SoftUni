using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreasingElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int tempLenght = 1;
            int prevNumber = int.Parse(Console.ReadLine());
            int maxLenght = 1;
            for (int i = 0; i < n - 1; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number > prevNumber)
                {
                    tempLenght++;
                    if (tempLenght > maxLenght)
                    {
                        maxLenght = tempLenght;
                    }
                }
                else
                {
                    tempLenght = 1;
                }
                prevNumber = number;

            }
            Console.WriteLine(maxLenght);
        }
    }
}