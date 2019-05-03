using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_1.Ремонт_на_плочки
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double L = double.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int O = int.Parse(Console.ReadLine());

            int area = 0;
            area = N * N;

            int areaO = 0;
            areaO = M*O;

            int restarea = 0;
            restarea = area - areaO;
            double areaP = 0;
            areaP = W * L;
            double neededP = 0;
            neededP = restarea / areaP;
            double neededT = 0;
            neededT = neededP * 0.2;
            Console.WriteLine(neededP);
            Console.WriteLine(neededT);
                      
        }
    }
}
