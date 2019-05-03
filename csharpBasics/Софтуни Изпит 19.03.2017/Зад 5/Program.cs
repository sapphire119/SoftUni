using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            var redove = (input * 2) + 1;
            var dotsLqvoGore = 0;
            var dotsDqsnoGore = input * 2;
            var dotsLqvoDolo = 0;
            var dotsDqsnoDolo = input * 2;
            Console.WriteLine("+{0}+{1}",
                new string('~', input - 2),
                new string('.', (input * 2) + 1));
            for (int i = 1; i <= redove; i++)
            {
                Console.WriteLine("|{0}\\{1}\\{2}",
                    new string('.', dotsLqvoGore),
                    new string('~', (input-2)),
                    new string('.',dotsDqsnoGore));
                dotsLqvoGore += 1;
                dotsDqsnoGore -= 1;
            }
            for (int p = 1; p <= redove; p++)
            {
                Console.WriteLine("{0}\\{1}|{2}|",
                    new string('.',dotsLqvoDolo),
                    new string('.',dotsDqsnoDolo),
                    new string('~',(input-2)));
                dotsLqvoDolo += 1;
                dotsDqsnoDolo -= 1;
            }
            Console.WriteLine("{0}+{1}+",
                new string('.', ((input * 2) + 1)),
                new string('~',(input - 2)));

        }
    }
}
