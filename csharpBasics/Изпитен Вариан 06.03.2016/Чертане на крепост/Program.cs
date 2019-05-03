using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Чертане_на_крепост
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());
            
            int SpaceOne = input / 2;
            int SpaceTwo = input / 2;
            int SpaceThree = input - 2;
            int SpaceBlank = (2 * input) - 2;
            int SpaceEmpty = input - 2;
            
            int total = (2 * input) - 4 - (SpaceOne * 2);
            int RestSpace = (SpaceBlank - total) / 2 ;


            if (input < 5)
            {
                Console.WriteLine("/{0}\\/{0}\\",
                        new string('^', SpaceOne));
            }
            else
            {
                Console.WriteLine("/{0}\\{1}/{0}\\",
                        new string('^', SpaceOne),
                        new string('_', total));
            }

            for (int i = 1; i <= SpaceThree; i++)
            {
                if (i < SpaceThree || i == SpaceThree && input <= 4)
                {
                    Console.WriteLine("|{0}|",
                    new string(' ', SpaceBlank));
                }
                else 
                {
                    Console.WriteLine("|{0}{1}{0}|",
                    new string(' ', RestSpace),
                    new string('_', total));
                }
            }
            if (input < 5)
            {
                Console.WriteLine("\\{0}/\\{0}/",
                        new string('_', SpaceOne));
            }
            else
            {
                Console.WriteLine("\\{0}/{1}\\{0}/",
                        new string('_', SpaceOne),
                        new string(' ', total));
            }



        }
    }
}
