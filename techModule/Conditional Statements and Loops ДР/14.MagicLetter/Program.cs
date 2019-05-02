using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = char.Parse(Console.ReadLine().ToLower());
            var second = char.Parse(Console.ReadLine().ToLower());
            var letterToSkip = char.Parse(Console.ReadLine().ToLower());

            for (char i = first; i <= second; i++)
            {
                for (char j = first; j <= second; j++)
                {
                    for (char k = first; k <= second; k++)
                    {
                        if (i==letterToSkip || j==letterToSkip || k==letterToSkip)
                        {
                            continue;
                        }
                        else
                        {
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }
        }
    }
}
