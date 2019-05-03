using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Правоъгълник_със_звездички_в_центъра
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());
            int SpaceBetween = (2*input)-2;
            int Space = input - 2;
            int InputLenghtEven = input - 1;
            int InputLenghtOdd = input - 2;

            Console.WriteLine(new string('%',input*2));
            if (input % 2 != 0)
            {
                for (int i = 1; i <=InputLenghtEven/2; i++)
                {
                    Console.WriteLine("%{0}%",
                        new string(' ',SpaceBetween));
                }
                Console.WriteLine("%{0}**{0}%",
                    new string(' ',Space));
                for (int i = 1; i <= InputLenghtEven/2; i++)
                {
                    Console.WriteLine("%{0}%",
                        new string(' ', SpaceBetween));
                }

            }
            else
            {
                for (int i = 1; i <= InputLenghtOdd / 2; i++)
                {
                    Console.WriteLine("%{0}%",
                        new string(' ', SpaceBetween));
                }
                Console.WriteLine("%{0}**{0}%",
                    new string(' ', Space));
                for (int i = 1; i <= InputLenghtOdd / 2; i++)
                {
                    Console.WriteLine("%{0}%",
                        new string(' ', SpaceBetween));
                }

            }
            Console.WriteLine(new string('%', input * 2));

        }
    }
}
