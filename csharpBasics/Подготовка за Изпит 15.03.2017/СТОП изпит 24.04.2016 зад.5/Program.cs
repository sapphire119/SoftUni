using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СТОП_изпит_24._04._2016_зад._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            var sum1 = 2 * input - 1;
            var tochkiGore = input;
            var formula = ((((4 * input) + 3) - 9) / 2);
            var tochkiDolo = 0;
            var formula2 = 4 * input - 1;
            Console.WriteLine("{0}{1}{0}",
                new string('.', input + 1),
                new string('_', input * 2 + 1));
            for (int i = 1; i <= input; i++)
            {
                Console.WriteLine("{0}//{1}\\\\{0}",
                    new string('.',tochkiGore),
                    new string('_',sum1));
                tochkiGore -= 1;
                sum1 += 2;
            }
            Console.WriteLine("//{0}STOP!{0}\\\\",
                new string('_',formula));
            for (int p = 1; p <= input; p++)
            {
                Console.WriteLine("{0}\\\\{1}//{0}",
                    new string('.',tochkiDolo),
                    new string('_',formula2));
                tochkiDolo += 1;
                formula2 -= 2;
            }
        }
    }
}
