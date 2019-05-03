using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Диамант
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = int.Parse(Console.ReadLine());

            var GorniTochki = input - 1;
            var TochkiGorni = input * 3;

            var dolenCikul =input * 2;

            var dolniTochki = 1;
            var DolnaProba = (2 * dolniTochki) + 2;
            var Tochkidolu = 5 * input;
            var IstinskaDolnaRazlika = Tochkidolu - DolnaProba;

            var Zvezdidolni = input - 2;
            var ZvezdniTochki = (input * 2) + 1;

            Console.WriteLine("{0}{1}{0}",
                new string('.', input),
                new string('*', 3 * input));

            for (int p = 1; p <= input - 1; p++) 
            {
                Console.WriteLine("{0}*{1}*{0}",
                    new string('.',GorniTochki),
                    new string('.',TochkiGorni));
                GorniTochki -= 1;
                TochkiGorni += 2;
            }
            Console.WriteLine("{0}",
                new string('*', input * 5));

            for (int i = 1; i <= dolenCikul; i++)
            {
                Console.WriteLine("{0}*{1}*{0}",
                    new string('.', dolniTochki),
                    new string('.', IstinskaDolnaRazlika));
                dolniTochki += 1;
                IstinskaDolnaRazlika = Tochkidolu - ((2 * dolniTochki) + 2);
            }
            Console.WriteLine("{0}{1}{0}",
                new string('.', ZvezdniTochki),
                new string('*', Zvezdidolni));
        }
    }
}
