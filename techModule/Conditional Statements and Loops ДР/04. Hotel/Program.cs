using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().ToLower();
            var days = int.Parse(Console.ReadLine());
            var CurrentDays = 0.0;

            var sumStudio = 0.0;
            var sumDouble = 0.0;
            var sumSuite = 0.0;

            if (input =="october")
            {
                sumDouble = 65 * days;
                sumSuite = 75 * days;
                if (days >7)
                {
                    sumStudio = 50 * 0.95;
                    CurrentDays = days - 1;
                    sumStudio = sumStudio * CurrentDays;
                }
                else
                {
                    sumStudio = 50 * days;
                }
            }
            else if (input == "september")
            {
                if (days > 7 && days <= 14)
                {
                    sumStudio = 60;
                    CurrentDays = days - 1;
                    sumStudio = sumStudio * CurrentDays;
                }
                else
                {
                    sumStudio = 60 * days;
                }
                if (days>14)
                {
                    sumDouble = 72 * 0.90;
                    sumDouble = sumDouble * days;
                }
                else
                {
                    sumDouble = 72 * days;
                }
                sumSuite = 82 * days;
            }
            else if (input == "july" || input == "august" || input == "december")
            {
                if (days > 14)
                {
                    sumSuite = (89 * 0.85)*days;
                }
                else
                {
                    sumSuite = 89 * days;
                }
                sumStudio = 68 * days;
                sumDouble = 77 * days;
            }
            else if (input == "june")
            {
                if (days > 14)
                {
                    sumDouble = (72 * 0.90) * days;
                }
                else
                {
                    sumDouble = 72 * days;
                }
                sumStudio = 60 * days;
                sumSuite = 82 * days;   
            }
            else if (input == "may")
            {
                if (days > 7)
                {
                    sumStudio = (50 * 0.95) * days;
                }
                else
                {
                    sumStudio = 50 * days;
                }
                sumDouble = 65 * days;
                sumSuite = 75 * days;   
            }
            Console.WriteLine($"Studio: {sumStudio:f2} lv.");
            Console.WriteLine($"Double: {sumDouble:f2} lv.");
            Console.WriteLine($"Suite: {sumSuite:f2} lv.");

        }
    }
}
