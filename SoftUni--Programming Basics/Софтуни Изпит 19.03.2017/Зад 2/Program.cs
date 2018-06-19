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
            var budget = double.Parse(Console.ReadLine());
            var plosht = double.Parse(Console.ReadLine());
            var prozorci = int.Parse(Console.ReadLine());
            var stiriopor = double.Parse(Console.ReadLine());
            var cenastiriopor = double.Parse(Console.ReadLine());

            var area = plosht - (prozorci * 2.4);
            area = area * 1.10;
            var packages = area / stiriopor;
            packages = Math.Ceiling(packages);
            var money = packages * cenastiriopor;

            if (money<budget)
            {
                Console.WriteLine("Spent: {0:f2}",money);
                Console.WriteLine("Left: {0:f2}",(budget - money));
            }
            else
            {
                Console.WriteLine("Need more: {0:f2}",money-budget);
            }


        }
    }
}
