﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_in_figure
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if (x >= 2 && x <= 12 && (y >= -3 && y <= 1))
            {
                Console.WriteLine("in");
            }
            else if (x >= 4 && x <= 10 && (y >= -5 && y <= 3)) 
            {
                Console.WriteLine("in");
            }
            else
            {
                Console.WriteLine(:);
            }
        }
    }
}
