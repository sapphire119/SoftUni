using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Кемп_СФ
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            int group1 = 0;
            int group2 = 0;
            int group3 = 0;
            int group4 = 0;
            int group5 = 0;
            double totalSum = 0;

            double p1;
            double p2;
            double p3;
            double p4;
            double p5;
           
            for (int i = 1; i <= input; i++)
            {

                var sum = int.Parse(Console.ReadLine());
                totalSum += sum;
                if (sum <=5)
                {
                    group1+=sum;
                }
                if (sum>=6 && sum<=12)
                {
                    group2+=sum;
                }
                if (sum >= 13 && sum <= 25)
                {
                    group3+=sum;
                }
                if (sum >= 26 && sum <= 40)
                {
                    group4+=sum;
                }
                if (sum >= 41)
                {
                    group5+=sum;
                }
            }

            p1 = group1 * 100 / totalSum;
            p2 = group2 * 100 / totalSum;
            p3 = group3 * 100 / totalSum;
            p4 = group4 * 100 / totalSum;
            p5 = group5 * 100 / totalSum;

            Console.WriteLine("{0:f2}%", p1);
            Console.WriteLine("{0:f2}%", p2);
            Console.WriteLine("{0:f2}%", p3);
            Console.WriteLine("{0:f2}%", p4);
            Console.WriteLine("{0:f2}%", p5);

        }
    }
}
