using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Битки
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int battles = int.Parse(Console.ReadLine());
            int iteracii = 0;
            for (int i = 1; i <= number1; i++)
            {
                for (int j = 1; j <= number2; j++)
                {
                    if (iteracii < battles)
                    {
                        Console.Write("({0} <-> {1}) ", i, j);
                        iteracii += 1;
                    }
                }

             
            }
        }
    }
}
