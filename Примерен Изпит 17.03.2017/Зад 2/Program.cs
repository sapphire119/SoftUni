using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var redove = (input - 1) / 2;
            var GorniTochki = input - 2;
            var GorniMejdinniTochki = 0;
            var DolniMejdinniTochki = input - 3;
            var DolniTochki = 1;

            Console.WriteLine("{0}{1}{0}",
                new string('.',input),
                new string('#',input));
            for (int i= 1; i <=redove; i++)
            {
                Console.WriteLine("{0}##{1}#{2}#{1}##{0}",
                    new string('.', GorniTochki),
                    new string('.', GorniMejdinniTochki),
                    new string('.',input-2));
                GorniTochki -= 2;
                GorniMejdinniTochki += 2;
            }
            for (int i = 1; i <= redove; i++)
            {
                Console.WriteLine("{0}##{1}#{2}#{1}##{0}",
                    new string('.', DolniTochki),
                    new string('.', DolniMejdinniTochki),
                    new string('.', input - 2));
                DolniTochki += 2;
                DolniMejdinniTochki -= 2;
            }
            Console.WriteLine("{0}{1}{0}",
                new string('.',input),
                new string('#',input));

        }
    }
}
