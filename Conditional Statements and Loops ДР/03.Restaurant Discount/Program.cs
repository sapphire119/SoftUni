using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var hall = Console.ReadLine();
            var sum = 0.0;
            var discount = 0.0;
            if (input<=50)
            {
                if (hall == "Normal")
                {
                    sum = 2500 + 500;
                    discount = sum * 0.05;
                    sum = sum - discount;
                    Console.WriteLine($"We can offer you the Small Hall\nThe price per person is {(sum/(double)input):f2}$");
                }
                else if (hall == "Gold")
                {
                    sum = 2500 + 750;
                    discount = sum * 0.10;
                    sum = sum - discount;
                    Console.WriteLine($"We can offer you the Small Hall\nThe price per person is {(sum/(double)input):f2}$");
                }
                else if (hall == "Platinum")
                {
                    sum = 2500 + 1000;
                    discount = sum * 0.15;
                    sum = sum - discount;
                    Console.WriteLine($"We can offer you the Small Hall\nThe price per person is {(sum / (double)input):f2}$");
                }
            }
            else if (input>50 && input<=100)
            {
                if (hall == "Normal")
                {
                    sum = 5000 + 500;
                    discount = sum * 0.05;
                    sum = sum - discount;
                    Console.WriteLine($"We can offer you the Terrace\nThe price per person is {(sum / (double)input):f2}$");
                }
                else if (hall == "Gold")
                {
                    sum = 5000 + 750;
                    discount = sum * 0.10;
                    sum = sum - discount;
                    Console.WriteLine($"We can offer you the Terrace\nThe price per person is {(sum / (double)input):f2}$");
                }
                else if (hall == "Platinum")
                {
                    sum = 5000 + 1000;
                    discount = sum * 0.15;
                    sum = sum - discount;
                    Console.WriteLine($"We can offer you the Terrace\nThe price per person is {(sum / (double)input):f2}$");
                }
            }
            else if (input>100 && input<=120)
            {
                if (hall == "Normal")
                {
                    sum = 7500 + 500;
                    discount = sum * 0.05;
                    sum = sum - discount;
                    Console.WriteLine($"We can offer you the Great Hall\nThe price per person is {(sum / (double)input):f2}$");
                }
                else if (hall == "Gold")
                {
                    sum = 7500 + 750;
                    discount = sum * 0.10;
                    sum = sum - discount;
                    Console.WriteLine($"We can offer you the Great Hall\nThe price per person is {(sum / (double)input):f2}$");
                }
                else if (hall == "Platinum")
                {
                    sum = 7500 + 1000;
                    discount = sum * 0.15;
                    sum = sum - discount;
                    Console.WriteLine($"We can offer you the Great Hall\nThe price per person is {(sum / (double)input):f2}$");
                }
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }

        }
    }
}
