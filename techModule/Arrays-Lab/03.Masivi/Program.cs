using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Masivi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(" ",
                Console.ReadLine().Split(' ').Select(int.Parse).ToArray().Reverse()));
            //Обръща стойностите на масива.
        }
    }
}
