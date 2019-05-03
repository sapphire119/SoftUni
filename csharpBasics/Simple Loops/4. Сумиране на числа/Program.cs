using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Сумиране_на_числа
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiredove = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 0; i < broiredove; i++)
            {
                double k = int.Parse(Console.ReadLine());
                
                sum = sum + k; 
            }
            Console.WriteLine(sum);

        }
    }
}
