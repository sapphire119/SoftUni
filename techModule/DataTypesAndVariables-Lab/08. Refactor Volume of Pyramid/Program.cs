﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double Height = double.Parse(Console.ReadLine());
            double Volume = (length * width * Height) / 3.0;
            Console.WriteLine("Pyramid Volume: {0:F2}", Volume);

        }
    }
}
