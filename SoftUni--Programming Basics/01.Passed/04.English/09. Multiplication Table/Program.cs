using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var constraint = int.Parse(Console.ReadLine());
           
            for (int i = 1; i <= 10; i++)
            {
                if (constraint<=i)
                {
                    Console.WriteLine($"{input} X {i} = {input * i}"); 
                }
               
            }
            if (constraint > 10)
            {
                Console.WriteLine($"{input} X {constraint} = {input * constraint}");

            }
        }
    }
}
