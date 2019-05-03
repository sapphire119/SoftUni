using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Стоп_Число
{
    class Program
    {
        static void Main(string[] args)
        {
            var PurvoChislo = int.Parse(Console.ReadLine());
            var Vtoro = int.Parse(Console.ReadLine());
            var StopChislo = int.Parse(Console.ReadLine());

            for (int i = Vtoro; i >= PurvoChislo; i--) 
            {
                
                if (i % 3 == 0 && i % 2 == 0)
                {
                    if (i==StopChislo)
                    {
                        return;
                    }
                    Console.Write("{0} ", i);
                }
                
            }
        }
    }
}
