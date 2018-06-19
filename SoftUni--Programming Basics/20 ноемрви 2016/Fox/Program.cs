using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int DotsBetween = (2 * n) - 1;
            int StarsBetween = (2 * n) - 1;
            int face = n / 3;
            int faceStars = n / 2;
            int DotsToPrint = 1;
            int StarsToPrint = 1;
            int p = n;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}\\{1}/{0}",
                    new string('*',StarsToPrint),
                    new string('-',DotsBetween));
                StarsToPrint += 1;
                DotsBetween -= 2;
            }
            for (int i = 0; i < face; i++)
            {
                Console.WriteLine("|{0}\\{1}/{0}|",
                    new string('*', faceStars),
                    new string('*', p));
                faceStars += 1;
                p -= 2;
            }
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}\\{1}/{0}",
                    new string('-', DotsToPrint),
                    new string('*', StarsBetween));
                DotsToPrint += 1;
                StarsBetween -= 2;
            }




        }
    }
}
