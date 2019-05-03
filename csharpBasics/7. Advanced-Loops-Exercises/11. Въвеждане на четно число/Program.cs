using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Въвеждане_на_четно_число
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter even number: ");
            int number;
            bool isParseSuccessful = int.TryParse(Console.ReadLine(), out number);

            bool numberInvalid = !(isParseSuccessful && number % 2 == 0);

            while (numberInvalid)
            {
                Console.WriteLine("Invalid number!");
                Console.Write("Enter even number: ");
                isParseSuccessful = int.TryParse(Console.ReadLine(), out number);
                numberInvalid = !(isParseSuccessful && number % 2 == 0);

            }
            Console.WriteLine("Even number entered: {0}",number);
        }

    }
}

