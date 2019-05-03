using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад_4
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter1 = char.Parse(Console.ReadLine());
            char letter2 = char.Parse(Console.ReadLine());
            char letterToSkip = char.Parse(Console.ReadLine());

            var sum = 0;

            for (char i = letter1; i <= letter2; i++)
            {
                for (char j = letter1; j <= letter2; j++)
                {
                    for (char p = letter1; p <= letter2; p++)
                    {
                        if (i == letterToSkip || j == letterToSkip || p == letterToSkip) 
                        {
                            continue;
                        }
                        else
                        {
                            sum += 1;
                            Console.Write("{0}{1}{2} ", i, j, p);
                        }
                        
                        
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
