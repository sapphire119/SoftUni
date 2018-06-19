using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Волейбол
{
    class Program
    {
        static void Main(string[] args)
        {

            string year = Console.ReadLine().ToLower();
            int holidays = int.Parse(Console.ReadLine());
            int away = int.Parse(Console.ReadLine());

            double value;
            double result;
            double value1;
            double total;
            double total1;
            double result1;
            if (away >=0 && year =="normal")
            {
                value = 48 - away;
                result = (value * 3.0) / 4;
                value1 = (holidays * 2.0) / 3;
                total = result + value1+away;
                Console.WriteLine(Math.Truncate(total));

            }
            else if (away >= 0 && year == "leap")
            {
                value = 48 - away;
                result = (value * 3.0) / 4;
                value1 = (holidays * 2.0) / 3;
                total = result + value1 + away;
                total1 = (total * 15) / 100;
                result1 = total + total1;
                Console.WriteLine(Math.Truncate(result1));

            }
            else
            {
                Console.WriteLine("error");
            }











        }
    }
}
