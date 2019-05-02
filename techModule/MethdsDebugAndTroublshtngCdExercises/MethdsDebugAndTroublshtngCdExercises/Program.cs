using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethdsDebugAndTroublshtngCdExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            PrintName(name);
        }

        private static void PrintName(string name)
        {
            Console.WriteLine(@"Hello, {0}!",name);
        }
    }
}
