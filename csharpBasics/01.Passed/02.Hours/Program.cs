using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Hours
{
    class Program
    {
        static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            minutes = minutes + 30;

            if (minutes>=60)
            {
                minutes = minutes % 60;
                hours++;
            }
            if (hours>=24)
            {
                hours = hours % 24;
            }
            if (minutes<=9)
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
        }
    }
}
