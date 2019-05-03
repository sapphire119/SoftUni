using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunken_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int Rounds = int.Parse(Console.ReadLine());
            int sumMitko = 0;
            int sumVladko = 0;
            int mejdinna = 0;
            int total = 0;

            for (int i = 1; i <= Rounds; i++)
            {
                int k = int.Parse(Console.ReadLine());
                string p = Convert.ToString(k);
                int Lenght = p.Length;

                if (Lenght % 2 == 0)
                {
                    for (int j = 1; j <= Lenght / 2; j++)
                    {
                        sumVladko += k % 10;
                        k /= 10;
                    }
                    for (int z = Lenght / 2; z >= 1; z--)
                    {
                        sumMitko += k % 10;
                        k /= 10;
                    }
                }
                else if (Lenght % 2 != 0 && Lenght != 1)
                {
                    mejdinna = k;
                    for (int j = 1; j <= (Lenght + 1) / 2; j++)
                    {
                        sumVladko += k % 10;
                        k /= 10;
                    }
                    for (int l = 1; l <= (Lenght - 1) / 2; l++)
                    {
                        mejdinna /= 10;
                    }
                    for (int z = (Lenght + 1) / 2; z >= 1; z--)
                    {
                        sumMitko += mejdinna % 10;
                        mejdinna /= 10;
                    }
                }
            }
            if (sumMitko == sumVladko)
            {
                Console.WriteLine("No {0}", total = sumVladko + sumVladko);
            }

            else if (sumVladko > sumMitko)
            {
                Console.WriteLine("V {0}", total = sumVladko - sumMitko);
            }
            else
            {
                Console.WriteLine("M {0}", total = sumMitko - sumVladko);
            }


        }
    }
}
