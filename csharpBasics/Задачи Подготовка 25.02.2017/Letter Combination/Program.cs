using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter_Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char lastLetter = char.Parse(Console.ReadLine());
            char LetterToSkip = char.Parse(Console.ReadLine());

            int combinationsPrinted = 0;
            for (char i=firstLetter; i <= lastLetter; i++)
            {
                for (char j = firstLetter; j<= lastLetter; j++)
                {
                    for (char k = firstLetter; k<=lastLetter; k++)
                    {
                        if (i ==LetterToSkip || j==LetterToSkip || k==LetterToSkip)
                        {
                            continue;
                        }
                        Console.Write("{0}{1}{2} ",i,j,k);
                        combinationsPrinted += 1;
                    }
                }
            }
            Console.WriteLine(combinationsPrinted);

        }
    }
}
