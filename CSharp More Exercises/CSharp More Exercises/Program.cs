using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_More_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var dotsSpaceUp = input - 2;
            var dotsToPrintUp = 0;
            var space = (input - 1) / 2;
            var dotsPrintDown = (input - 3) / 2;
            var dotsSpaceDown = 1;

            for (int i = 1; i <= input/2; i++)
            {
                Console.WriteLine("{0}x{1}x",new string(' ',dotsToPrintUp),
                    new string(' ',dotsSpaceUp));
                dotsToPrintUp++;
                dotsSpaceUp-=2;
            }
            Console.WriteLine("{0}x{0}",new string(' ',space));

            for (int i = 1; i <= input / 2; i++)
            {
                Console.WriteLine("{0}x{1}x", new string(' ', dotsPrintDown),
                    new string(' ', dotsSpaceDown));
                dotsPrintDown--;
                dotsSpaceDown += 2;  
            }

        }
    }
}
