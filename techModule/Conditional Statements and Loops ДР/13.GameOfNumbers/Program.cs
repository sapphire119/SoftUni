using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var thirdNumber = int.Parse(Console.ReadLine());
            var Current_I = 0;
            var Current_J = 0;
            var iterator = 0;
            for (int i = firstNumber; i <= secondNumber; i++)
            {
                for (int j = firstNumber; j <= secondNumber; j++)
                {
                    iterator++;
                    if (thirdNumber==(i+j))
                    {
                        Current_I = i;
                        Current_J = j;
                    }
                    if ((i==secondNumber && j==secondNumber) && (Current_I !=0 || Current_J !=0 ))
                    {
                        Console.WriteLine("Number found! {0} + {1} = {2}",Current_I,Current_J,thirdNumber);
                    }
                }
            }
            if ((Current_I+Current_J) !=thirdNumber)
            {
                Console.WriteLine("{0} combinations - neither equals {1}",iterator,thirdNumber);
            }
        }
    }
}
