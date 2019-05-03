using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallen_In_Love
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int betweenSymbol = 0;
            int betweenDot1 = 2 * n;
            int betweenDot2 = 0;
            int dots1 = 1;
            int space = n;
            int BetweenDots = 2 * n;
            int SymbolDots = 2 * n + 1;
            int MoreDots = 2 * n + 2;
            
            for (int i = 1; i <=n; i++)
            {
                Console.WriteLine("#{0}#{1}#{2}#{1}#{0}#",
                new string('~',betweenSymbol),
                new string('.',betweenDot1),
                new string('.',betweenDot2));
                betweenSymbol += 1;
                betweenDot1 -= 2;
                betweenDot2 += 2;
            }
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine("{0}#{1}#{2}#{1}#{0}",
                    new string('.',dots1),
                    new string('~',space),
                    new string('.',BetweenDots));
                dots1 += 2;
                space -= 1;
                BetweenDots -= 2;
            }
            Console.WriteLine("{0}####{0}",
                new string('.',SymbolDots));
            for (int k = 0; k < n; k++)
            {
                Console.WriteLine("{0}##{0}",
                    new string('.',MoreDots));

            }
        }
    }
}
