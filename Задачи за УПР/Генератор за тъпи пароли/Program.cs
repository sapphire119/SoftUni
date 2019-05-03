using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Генератор_за_тъпи_пароли
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int p = l + 96;
            char g = (char) p;
            int max = 2;
            int MaxValue = 0;

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (max>=i || max>=j)
                    {
                        max = 2;
                        MaxValue = Math.Max(i, j);
                        max = MaxValue + 1;
                    }
                    for (char z = 'a'; z <= p; z++)
                    {
                        for (char x = 'a'; x <= p; x++)
                        {
                            
                            for (int c =max ; c <= n; c++)
                            {
                                Console.Write("{0}{1}{2}{3}{4} ", i, j, z, x, c);
                            }
                        }
                    }
                }
            }


        }
    }
}
