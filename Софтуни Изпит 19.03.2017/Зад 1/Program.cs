using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var loze = double.Parse(Console.ReadLine());
            var grozdeKVm = double.Parse(Console.ReadLine());
            var brak = double.Parse(Console.ReadLine());

            var result = loze * grozdeKVm;
            result = result - brak;
            var rakia = result * 0.45;
            rakia = rakia / 7.5;
            var prihod = rakia * 9.80;

            var sale = result * 0.55;
            var sales = sale * 1.50;

            Console.WriteLine("{0:f2}",prihod);
            Console.WriteLine("{0:f2}",sales);


        }
    }
}
