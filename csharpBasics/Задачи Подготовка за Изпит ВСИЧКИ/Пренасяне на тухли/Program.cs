using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пренасяне_на_тухли
{
    class Program
    {
        static void Main(string[] args)
        {
            int tuhli = int.Parse(Console.ReadLine());
            int rabotnici = int.Parse(Console.ReadLine());
            int vmestimost = int.Parse(Console.ReadLine());

            double total = 0;
            total = rabotnici * vmestimost;
            double total1 = 0;
            total1 = tuhli / total;
            Console.WriteLine("{0:0}", Math.Ceiling(total1));
            
        }
    }
}
