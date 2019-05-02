using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Triples_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            for (int numOne = 1; numOne <= input; numOne++) 
            {
                for (int numTwo = 1; numTwo <= input; numTwo++)
                {
                    for (int numThree = 1; numThree <= input; numThree++)
                    {
                        char firstLetter = (char)('a' + numOne - 1);
                        char secondLetter = (char)('a' + numTwo - 1);
                        char thirdLetter = (char)('a' + numThree - 1);
                        Console.WriteLine("{0}{1}{2}",firstLetter,secondLetter,thirdLetter);
                    }
                }
            }
        }
    }
}
