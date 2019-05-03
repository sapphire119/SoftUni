using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Точка_в_правоъгълник
{
    class Program
    {
        static void Main(string[] args)
        {

            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());


            if (x2 <= x1 || y2 <= y1)
            {
                Console.WriteLine(" X2(Y2) must be bigger than X1(Y1)");
            }
            else if (x <=x2 && x>=x1)
            {
                if (y<=y2 && y>=y1)
                {
                    Console.WriteLine("Inside");
                }
                else
                {
                    Console.WriteLine("Outside");
                }
            }
            else
            {
                Console.WriteLine("Outside");
            }



        }
    }
}
