﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Centuries_to_Nanoseconds
{
    class Program
    {
        static void Main(string[] args)
        {
            checked
            {
                byte centuries = byte.Parse(Console.ReadLine());
                int years = centuries * 100;
                int days = (int)(years * 365.2422);
                int hours = days * 24;
                int minutes = hours * 60;
                ulong seconds = (ulong)minutes * 60;
                decimal miliseconds = seconds * 1000m;
                decimal microseconds = miliseconds * 1000m;
                decimal nanoseconds = microseconds * 1000m;
                Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds", centuries, years, days, hours, minutes, seconds, miliseconds, microseconds, nanoseconds);
            }
        }
    }
}
