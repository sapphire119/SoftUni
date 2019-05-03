using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Парички
{
    class Program
    {
        static void Main(string[] args)
        {
            var bitcoin = int.Parse(Console.ReadLine());
            var juan = double.Parse(Console.ReadLine());
            var commission = double.Parse(Console.ReadLine());

            var bitSUM = bitcoin * 1168;
            var juanSUM = juan * 0.15;
            juanSUM = juanSUM * 1.76;
            double totalSUM = juanSUM + bitSUM;
            totalSUM = totalSUM / 1.95;
            var CommissionSUM = (totalSUM/100) * commission;
            var result = totalSUM - CommissionSUM;
            Console.WriteLine(result);

        }
    }
}
