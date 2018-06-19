using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Реколта
{
    class Program
    {
        static void Main(string[] args)
        {

            var areaLoze = int.Parse(Console.ReadLine());
            double GrozdePerFoot = double.Parse(Console.ReadLine());
            var NeededWine = int.Parse(Console.ReadLine());
            var workers = int.Parse(Console.ReadLine());

            var totalgrozde = areaLoze * GrozdePerFoot;
            var wine = 0.40 * totalgrozde / 2.5;
            double diffrence = 0;
            double winePerWorker = 0;
            if (wine>=NeededWine)
            {
                diffrence = wine - NeededWine;
                winePerWorker = diffrence / workers;
                Console.WriteLine("Good harvest this year! Total wine: {0} liters.",
                    Math.Floor(wine));
                Console.WriteLine("{0} liters left -> {1} liters per person.",
                    Math.Ceiling(diffrence),Math.Ceiling(winePerWorker));
            }
            else
            {
                diffrence = NeededWine - wine;
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.",
                    Math.Floor(diffrence));
            }

        }
    }
}
