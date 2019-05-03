using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Време___15_минути
{
    class Program
    {
        static void Main(string[] args)
        {
            int chas = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            int razlika = 15;
            if (chas >= 0 && chas <= 22)
            {
                if (min >= 45 && min <= 54)
                {
                    min += razlika;
                    min -= 60;
                    chas += 1;
                    Console.WriteLine("{0}:0{1}", chas, min);
                }
                else if (min >= 55)
                {
                    min += razlika;
                    min -= 60;
                    chas += 1;
                    Console.WriteLine("{0}:{1}", chas, min);
                }
                else
                {
                    min += razlika;
                    Console.WriteLine("{0}:{1}", chas, min);
                }

            }
            else if (chas == 23)
            {
                if (min >= 45 && min <= 54)
                {
                    min += razlika;
                    min -= 60;
                    chas += 1;
                    chas -= 24;
                    Console.WriteLine("{0}:0{1}", chas, min);
                }
                else if (min >= 55)
                {
                    min += razlika;
                    min -= 60;
                    chas += 1;
                    chas -= 24;
                    Console.WriteLine("{0}:{1}", chas, min);
                }
                else
                {
                    min += razlika;
                    Console.WriteLine("{0}:{1}", chas, min);
                }
            }


            }
    }
}
