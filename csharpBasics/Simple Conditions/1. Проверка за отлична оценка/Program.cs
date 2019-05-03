using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Проверка_за_отлична_оценка
{
    class Program
    {
        static void Main(string[] args)
        {

            double grade = double.Parse(Console.ReadLine());

            if (grade >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }

        }
    }
}
