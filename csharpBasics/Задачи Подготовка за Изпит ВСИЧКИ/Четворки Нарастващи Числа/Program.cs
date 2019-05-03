using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Четворки_Нарастващи_Числа
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int diffrence = Math.Abs(numberTwo - numberOne);

            if (diffrence <= 2)
            {
                Console.WriteLine("No");
                
            }

            for (int i = numberOne; i <= numberTwo-3; i++)
            {
                for (int j = numberOne+1; j <=numberTwo-2; j++)
                {
                    for (int k = numberOne+2; k <= numberTwo-1; k++)
                    {
                        for (int p = numberOne + 3; p <= numberTwo; p++) 
                        {
                            if (i < j && j < k && k < p && i < p)
                            {
                                Console.WriteLine("{0} {1} {2} {3}", i, j, k, p);
                            }
                            
                        }
                    }
                }
            }

        }
    }
}
