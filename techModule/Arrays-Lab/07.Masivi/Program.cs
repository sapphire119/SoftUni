using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Masivi
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 5;
            var b = 6;
            Swap(ref a, ref b);
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
        
        static void Swap<T>(ref T a,ref T b)
        {
            var oldA = a;
            a = b;
            b = oldA;
        }
    }
}
