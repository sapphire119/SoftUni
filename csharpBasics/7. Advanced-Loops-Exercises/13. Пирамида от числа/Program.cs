using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Триъгълник_от_долари
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    count += 1;
                    Console.Write("{0} ",count);
                    if (count==n)
                    {
                        Console.WriteLine();
                        return;
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
