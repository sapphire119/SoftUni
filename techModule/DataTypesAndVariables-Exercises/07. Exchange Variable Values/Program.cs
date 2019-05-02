using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Exchange_Variable_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            //Before:
            //a = 5
            //b = 10
            //After:
            //a = 10
            //b = 5

            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            Console.WriteLine("Before:\na = {0}\nb = {1}", a, b);
            var c = 0;
            c = b;
            b = a;
            a = c;
            Console.WriteLine("After:\na = {0}\nb = {1}", a, b);


        }
    }
}
