using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Бонус_точки
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter score: ");
            double number = double.Parse(Console.ReadLine());
            double total;
            double bonus;
            {
                if (number <= 100)
                {
                    bonus = 5;
                    if (number % 2 == 0)
                    {
                        bonus += 1;
                    }
                    else if (number % 5 == 0)
                    {
                        bonus += 2;
                    }

                    Console.WriteLine("Bonus Score: {0}", bonus);
                    total = bonus + number;
                    Console.WriteLine("Total Score: {0}",total);
                }

                else if (number > 100 && number <= 1000)
                {
                   bonus = (number * 20) / 100;
                    if (number % 2 == 0)
                    {
                        bonus += 1;
                    }
                    else if (number % 5 == 0)
                    {
                        bonus += 2;
                    }


                    Console.WriteLine("Bonus Score: {0}", bonus);
                    total = bonus + number;
                    Console.WriteLine("Total Score: {0}", total);

                }

                else if (number > 1000)
                {
                    bonus = (number * 10) / 100;
                    if (number % 2 == 0)
                    {
                        bonus += 1;
                    }
                    else if (number % 5 == 0)
                    {
                        bonus += 2;
                    }

                    Console.WriteLine("Bonus Score: {0}", bonus);
                    total = bonus + number;
                    Console.WriteLine("Total Score: {0}", total);
                }


                

                

            }



        }
    }
}
