using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var months = int.Parse(Console.ReadLine());

            double sumTok, sumVoda, sumInet,sumDrugi;
            double average;
            sumTok = sumVoda = sumInet = sumDrugi = average = 0;

            for (int i = 1; i <= months; i++)
            {
                double tok = double.Parse(Console.ReadLine());
                sumTok += tok;
                
            }
            sumVoda = months * 20;
            sumInet = months * 15;
            sumDrugi = sumTok + sumInet + sumVoda;
            sumDrugi = sumDrugi * 1.20;
            average = (sumTok + sumVoda + sumInet + sumDrugi) / months;

            Console.WriteLine("Electricity: {0:f2} lv",sumTok);
            Console.WriteLine("Water: {0:f2} lv",sumVoda);
            Console.WriteLine("Internet: {0:f2} lv", sumInet);
            Console.WriteLine("Other: {0:f2} lv", sumDrugi);
            Console.WriteLine("Average: {0:f2} lv", average);

        }
    }
}
