using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Елемент__равен_на_сумата_на_останалите
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int sum = 0;
            int sum1;
            int diffrence;
            
            for (int i = 1; i <= n; i++)
            {
                int k = int.Parse(Console.ReadLine());
               
                if (max < k)
                {
                    max = k;
                    
                }
                sum = sum + k;
                    
            }
            
            sum1 = Math.Abs(max - sum);
            diffrence = Math.Abs(max - sum1);
            

            if (max == sum1)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = "+sum1);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff= "+diffrence);
            }
        }
    }
}
