﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Специални_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <=9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int p = 1; p <=9; p++)
                        {
                            if(n % p == 0 && n % k == 0 && n % j == 0 && n % i == 0)
                            {
                                Console.Write("{0}{1}{2}{3} ",i,j,k,p);
                            }
                        }
                    }
                }
            }

        }
    }
}
