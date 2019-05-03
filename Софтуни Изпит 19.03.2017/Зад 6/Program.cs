using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var redPurvi = int.Parse(Console.ReadLine());
            var redVtori = int.Parse(Console.ReadLine());
            var KontrolnoChislo = int.Parse(Console.ReadLine());
            int sum, result;
            sum = result = 0;
            int iterator = 0;
            for (int i = 1; i <= redPurvi; i++)
            {
                for (int j = redVtori; j >= 1; j--) 
                {
                    if (sum>=KontrolnoChislo)
                    {
                        Console.WriteLine("{0} moves",iterator);
                        Console.WriteLine("Score: {0} >= {1}",sum,KontrolnoChislo);
                        return;
                    }
                    result = i * 2 + j * 3;
                    sum = sum + result;
                    iterator += 1;

                }
            }
            Console.WriteLine("{0} moves",iterator);
        }
    }
}
