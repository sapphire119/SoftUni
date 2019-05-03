using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Числата_от_N_до_1_в_обратен_ред
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = input; i >= 1; i--)
            {
                Console.WriteLine(input);
                input -= 1;
            }


        }
    }
}
