using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Slav
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int dotsPerSideinUpperPart = n / 2 - 1;
            int dotsBetweenHashtagsInUpperPart = 0;
            int upperPartHeight = n / 2;
            for (int i = 0; i < upperPartHeight; i++)
            {
                Console.WriteLine("{0}#{1}#{0}",
                    new string('.',dotsPerSideinUpperPart),
                    new string('.',dotsBetweenHashtagsInUpperPart));
                dotsBetweenHashtagsInUpperPart += 2;
                dotsPerSideinUpperPart -= 1;
            }
            int dotsPerSideInMIddlePart = 0;
            int dotsBetweenHashTagsInMIddlePart = 
                n - (dotsPerSideInMIddlePart * 2 + 2);
            int middlePart = n / 4;
            for (int i = 0; i < middlePart; i++)
            {
                Console.WriteLine("{0}#{1}#{0}",
                    new string('.',dotsPerSideInMIddlePart),    
                    new string('.',dotsBetweenHashTagsInMIddlePart));
                dotsPerSideInMIddlePart++;
                dotsBetweenHashTagsInMIddlePart -= 2;
            }
            Console.WriteLine(new string('-',n));
        }
    }
}
