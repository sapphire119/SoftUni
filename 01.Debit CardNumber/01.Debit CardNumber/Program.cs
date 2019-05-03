using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Debit_CardNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var numb1 = int.Parse(Console.ReadLine());
            var numb2 = int.Parse(Console.ReadLine());
            var numb3 = int.Parse(Console.ReadLine());
            var numb4 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{numb1:D4} {numb2:D4} {numb3:D4} {numb4:D4} ");
        }
    }
}
