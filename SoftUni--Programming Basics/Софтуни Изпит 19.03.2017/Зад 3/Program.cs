using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var sezon = Console.ReadLine().ToLower();
            var kilometri = double.Parse(Console.ReadLine());
            double cena = 0;
            
            if (sezon =="spring" || sezon=="autumn")
            {
                if (kilometri<=5000)
                {
                    cena = 0.75 * kilometri;
                    cena = (cena * 4) * 0.90;
                }
                else if (kilometri>5000 && kilometri<=10000)
                {
                    cena = 0.95 * kilometri;
                    cena = (cena * 4) * 0.90;
                }
                else if (kilometri>10000 && kilometri<=20000)
                {
                    cena = 1.45 * kilometri;
                    cena = (cena * 4) * 0.90;
                }
            }
            else if (sezon =="summer")
            {
                if (kilometri <= 5000)
                {
                    cena = 0.90 * kilometri;
                    cena = (cena * 4) * 0.90;
                }
                else if (kilometri > 5000 && kilometri <= 10000)
                {
                    cena = 1.10 * kilometri;
                    cena = (cena * 4) * 0.90;
                }
                else if (kilometri > 10000 && kilometri <= 20000)
                {
                    cena = 1.45 * kilometri;
                    cena = (cena * 4) * 0.90;
                }
            }
            else if (sezon=="winter")
            {
                if (kilometri <= 5000)
                {
                    cena = 1.05 * kilometri;
                    cena = (cena * 4) * 0.90;
                }
                else if (kilometri > 5000 && kilometri <= 10000)
                {
                    cena = 1.25 * kilometri;
                    cena = (cena * 4) * 0.90;
                }
                else if (kilometri > 10000 && kilometri <= 20000)
                {
                    cena = 1.45 * kilometri;
                    cena = (cena * 4) * 0.90;
                }
            }

            Console.WriteLine("{0:f2}",cena);

        }
    }
}
