﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Информация_за_скоростта
{
    class Program
    {
        static void Main(string[] args)
        {

            double skorost = double.Parse(Console.ReadLine());

            if (skorost <=10)
            {
                Console.WriteLine("slow");
            }
            else if (skorost >10 && skorost<=50)
            {
                Console.WriteLine("average");
            }
            else if (skorost >50 && skorost <=150)
            {
                Console.WriteLine("fast");
            }
            else if (skorost >150 && skorost <=1000)
            {
                Console.WriteLine("ultra fast");
            }
            else
            {
                Console.WriteLine("extremely fast");
            }

        }
    }
}
