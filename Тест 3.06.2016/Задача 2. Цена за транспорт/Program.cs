using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_2.Цена_за_транспорт
{
    class Program
    {
        static void Main(string[] args)
        {

            double razstoqnie = double.Parse(Console.ReadLine());
            string time = Console.ReadLine().ToLower();

            double suma;
            double suma1;


            
            if (razstoqnie <20 && razstoqnie>=0)
            {
                if (time =="day")
                {
                    suma1 = 0.79 * razstoqnie;
                    suma = 0.70 + (suma1);
                    Console.WriteLine(suma);
                }
                else if (time =="night")
                {
                    suma1 = 0.90 * razstoqnie;
                    suma = 0.70 +suma1;
                    Console.WriteLine(suma);

                }
            }
            else if (razstoqnie>=20 && razstoqnie<100)
            {
                if (time =="day" || time =="night")
                {
                    suma = razstoqnie * 0.09;
                    Console.WriteLine(suma);

                }

            }
            else if (razstoqnie >= 100 && razstoqnie<=5000)
            {
                if (time =="day" || time =="night")
                {
                    suma = razstoqnie * 0.06;
                    Console.WriteLine(suma);

                }
            }


        }
    }
}
