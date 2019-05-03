using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Числа_на_Фибоначи
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int oldValue = 1;
            int newValue = 0;
            for (int i = 0; i < number+1; i++)
            {
                newValue = oldValue + newValue;
                oldValue = newValue - oldValue;
            }
            if (number ==0)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(newValue);
            }
            
        }
    }
}
4