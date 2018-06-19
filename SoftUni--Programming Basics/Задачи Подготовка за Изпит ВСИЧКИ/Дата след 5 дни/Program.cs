using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дата_след_5_дни
{
    class Program
    {
        static void Main(string[] args)
        {

            int d = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            //   04.06.09.11 = 30     02=28
            int Days = 0;
            int TotalDays = 0;
            int TotalMonths = 0;
            int total = 0;
            if (m != 2 && m != 4 && m != 6 && m != 9 && m != 11)
            {
                Days = d + 5;
                TotalDays = Days % 31;
                TotalMonths = Days / 31;
                total = TotalMonths + m;
                if (Days==31)
                {
                    TotalDays = 31;
                    total = m;
                }
            }
            else if (m == 2)
            {
                Days = d + 5;
                TotalDays = Days % 28;
                TotalMonths = Days / 28;
                total = TotalMonths + m;
                if (Days == 28)
                {
                    TotalDays = 28;
                    total = m;
                }
            }
            else
            {
                Days = d + 5;
                TotalDays = Days % 30;
                TotalMonths = Days / 30;
                total = TotalMonths + m;
                if (Days == 30)
                {
                    TotalDays = 30;
                    total = m;
                }
            }

            if (total == 13)
            {
                total /= 12;
            }
            Console.WriteLine("{0}.{1:00}", TotalDays, total);




        }
    }
}
