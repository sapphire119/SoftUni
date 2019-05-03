using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Кино
{
    class Program
    {
        static void Main(string[] args)
        {

            var type = Console.ReadLine().ToLower();
            var redove = int.Parse(Console.ReadLine());
            var koloni = int.Parse(Console.ReadLine());
            int broi = redove * koloni;
            double result;
            switch (type)
            {

                case "premiere": result = broi * 12; Console.WriteLine("{0:f2} leva",result);break;
                case "normal": result = broi * 7.50; Console.WriteLine("{0:f2} leva", result); break;
                case "discount": result = broi * 5; Console.WriteLine("{0:f2} leva", result); break;
                default:
                    Console.WriteLine("error");
                    break;
            }





        }
    }
}
