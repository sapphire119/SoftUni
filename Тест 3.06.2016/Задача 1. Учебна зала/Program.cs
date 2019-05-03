using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_1.Учебна_зала
{
    class Program
    {
        static void Main(string[] args)
        {

            double length1 = double.Parse(Console.ReadLine());
            double width1 = double.Parse(Console.ReadLine());
            

            double width;
            double length;

            width = width1 * 100;
            length = length1 * 100;

            int result;
            int Nwidth;

            double Nlength;
            double total;
            if (width1 >=3 && width1 <=length1 && length1<=100)
            {

                Nlength = (int)length / 120;
                Console.WriteLine("Broi redove ={0}",Nlength);

                Nwidth = (int) width - 100;
                result = Nwidth / 70;
                Console.WriteLine("{0} bura",result);
                total = result * Nlength;
                total -= 3;
                Console.WriteLine(total);


            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
