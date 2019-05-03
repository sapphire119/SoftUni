using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Проверка_за_просто_число
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            
            for (int i = 2; i <= n; i++)
            {
                if (n % i == 0)
                {
                    sum += 1;
                    if (sum >1)
                    {
                        break;
                    }
                }
            }
            if (sum > 1 || n <= 1)
            {
                Console.WriteLine("Not Prime");
            }
            else if (sum <= 1)
            {
                Console.WriteLine("Prime");
            }

        }
    }
}
