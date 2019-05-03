using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Поредица_от_нарастващи_елементи
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());
            int LastValue = 0;
            int broi = 1;
            int mejdinna = 0;
            for (int i = 1; i <= input; i++)
            {
                if (i==1)
                {
                    int number = int.Parse(Console.ReadLine());
                    LastValue = number;
                }
                else
                {
                    int number = int.Parse(Console.ReadLine());
                    if (LastValue<number)
                    {
                        broi += 1;
                    }
                    else
                    {
                        broi = 1;
                    }
                    if (mejdinna < broi)
                    {
                        mejdinna = broi;
                    }
                    LastValue = number;
                }
            }
            if (input > 1)
            {
                Console.WriteLine(mejdinna);
            }
            else if (input == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
