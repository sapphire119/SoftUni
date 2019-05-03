using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = Console.ReadLine().ToLower();
            var age = int.Parse(Console.ReadLine());



            if (day == "weekday" && ((age >= 0 && age <= 18) || (age > 64 && age <= 122)))
            {
                Console.WriteLine("12$");
            }
            else if (day == "weekday" && (age > 18 && age <= 64))
            {
                Console.WriteLine("18$");
            }

            else if (day == "weekend" && ((age >= 0 && age <= 18) || (age > 64 && age <= 122)))
            {
                Console.WriteLine("15$");
            }
            else if (day == "weekend" && (age > 18 && age <= 64))
            {
                Console.WriteLine("20$");
            }

            else if (day == "holiday" && (age >= 0 && age <= 18))
            {
                Console.WriteLine("5$");
            }
            else if (day == "holiday" && (age > 18 && age <= 64))
            {
                Console.WriteLine("12$");
            }
            else if (day == "holiday" && (age > 64 && age <= 122))
            {
                Console.WriteLine("10$");
            }
            else
            {
                Console.WriteLine("Error!");
            }


        }
    }
}
