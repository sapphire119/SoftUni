﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Еднакви_думи
{
    class Program
    {
        static void Main(string[] args)
        {


            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            double number3 = double.Parse(Console.ReadLine());

            
            if (number1 == number2)
            {
                if (number2 == number3)
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }

            }
            else
            {
                Console.WriteLine("no");
            }
            


        }
    }
}
