using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Число_в_диапазона__1_100_
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Еnter a number in the range [1...100]: ");
            int number = int.Parse(Console.ReadLine());
            while (number <1 || number > 100)
            {
                Console.WriteLine("Invalid number!");
                Console.Write("Еnter a number in the range [1...100]: ");
                number = int.Parse(Console.ReadLine());
                
            }
            
            Console.WriteLine("The number is: "+number);




        }
    }
}

