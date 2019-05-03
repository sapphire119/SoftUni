using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Четни_степени_на_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 0; i <= input; i++)
            {
                if (i%2==0)
                {
                    Console.WriteLine("{0}", Math.Pow(2, i));
                }
            }

        }
    }
}
