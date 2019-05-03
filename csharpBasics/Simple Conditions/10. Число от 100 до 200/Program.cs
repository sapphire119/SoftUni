using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Число_от_100_до_200
{
    class Program
    {
        static void Main(string[] args)
        {


            int chislo = int.Parse(Console.ReadLine());

            if (chislo <100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (chislo >=100 && chislo <=200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else if (chislo >200)
            {
                Console.WriteLine("Greater than 200");
            }

        }
    }
}
