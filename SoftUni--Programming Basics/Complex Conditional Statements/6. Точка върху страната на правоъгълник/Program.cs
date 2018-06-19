using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Точка_върху_страната_на_правоъгълник
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


            bool value = (x < x2 && x > x1 && y < y2 && y > y1);
            bool value1 = (x == x1 || x == x2) && y <= y2 && y >= y1;
            bool value2 = (y == y1 || y == y2) && x <= x2 && x >= x1;
            if (x2 <= x1 || y2 <= y1)
            {
                Console.WriteLine(" X2(Y2) must be bigger than X1(Y1)");
            }
            else if (value)
            { 
                    Console.WriteLine("Inside / Outside");
            }
            else if (value1 || value2)
            {
                Console.WriteLine("Border");
            }
            else if(!(value))
            {
                Console.WriteLine("Inside / Outside");
            }

            

            







        }
    }
}
