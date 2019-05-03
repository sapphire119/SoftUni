using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Магически_числа
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <=10; i++)
            {
                for (int j = 1 ; j <=10 ; j++)
                {
                    for (int k = 1; k <= 10; k++)
                    {
                        for (int z = 1; z <= 10; z++)
                        {
                            for (int x =1; x <= 10; x++)
                            {
                                for (int c = 1; c <= 10; c++)
                                {
                                    if (i*j*k*z*x*c ==n)
                                    {
                                        Console.Write("{0}{1}{2}{3}{4}{5} ", i, j, k, z, x, c);
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
