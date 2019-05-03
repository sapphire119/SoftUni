using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_2.Поспаливата_котка_Том
{
    class Program
    {
        static void Main(string[] args)
        {

            int Pochivka = int.Parse(Console.ReadLine());

            double x1;
            x1 = Pochivka * 127;
            int x2;
            x2 = 365 - Pochivka;
            double x3;
            x3 = x2 * 63;
            double add;
            add = x3 + x1;
            double time;
            time = Math.Abs(add - 30000);


            int hours = (int)time / 60;
            int minutes = (int)time % 60;
            if (add > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0} hours and {1} minutes more for play", hours, minutes);
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0} hours and {1} minutes less for play", hours, minutes);
            }
        }
                    
    }
}
