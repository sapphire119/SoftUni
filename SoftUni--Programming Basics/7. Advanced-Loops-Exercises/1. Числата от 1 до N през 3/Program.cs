using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Числата_от_1_до_N_през_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 1;
            do
            {
                Console.WriteLine(sum);
                sum += 3;
            } while (sum<=n);

        }
    }
}
