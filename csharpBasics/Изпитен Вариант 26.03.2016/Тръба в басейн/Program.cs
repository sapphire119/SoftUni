using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тръба_в_басейн
{
    class Program
    {
        static void Main(string[] args)
        {
            int V = int.Parse(Console.ReadLine());
            int P1 = int.Parse(Console.ReadLine());
            int P2 = int.Parse(Console.ReadLine());
            double H = double.Parse(Console.ReadLine());
            var total = P1*H +P2*H;

            if (total > V)
            {
                var diffrence = total - V;
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.", H, diffrence);
            }
            else
            {
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.",
                    Math.Truncate(total/V*100),
                    Math.Truncate(P1*H/total*100),
                    Math.Truncate(P2*H/total*100));
            }
        }
    }
}
