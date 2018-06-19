using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Завръщане_в_миналото
{
    class Program
    {
        static void Main(string[] args)
        {

            var moneyInherited = double.Parse(Console.ReadLine());
            var year = int.Parse(Console.ReadLine());

            year = year - 1800;
            double spendMoney = 0;
            double Leftmoney = moneyInherited;
            int IvanchoYears = 18;
            for (int yrs = 0; yrs <= year; yrs++)
            {
                if (yrs % 2 == 0)
               {
                    Leftmoney = Leftmoney - 12000;
               }
               else if (yrs % 2 != 0)
               {
                   spendMoney = 12000 +50*IvanchoYears;
                    Leftmoney = Leftmoney - spendMoney;
               }
                IvanchoYears += 1;

            }

            if (Leftmoney>=0)
            {
                Console.WriteLine("Yes! He will live a carefree life and will have {0:f2} dollars left.",
                    Leftmoney);
            }
            else
            {
                Console.WriteLine("He will need {0:f2} dollars to survive.",
                    Math.Abs(Leftmoney));
            }
        }
    }
}
