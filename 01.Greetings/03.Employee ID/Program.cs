﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employee_ID
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var ID = int.Parse(Console.ReadLine());
            var salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Name: {0}",name);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine("Employee ID: {0:d8}", ID);
            Console.WriteLine("Salary: {0:f2}", salary);

        }
    }
}
