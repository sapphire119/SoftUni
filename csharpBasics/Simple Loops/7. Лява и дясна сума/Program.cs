using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Лява_и_дясна_сума
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiChisla = int.Parse(Console.ReadLine());
            int Sumleft = 0;
            int SumRight = 0;
            int total;
            int diffrence;
            for (int i = 0; i < broiChisla; i++)
            {
                int k = int.Parse(Console.ReadLine());
                Sumleft += k;
            }
            for (int i = 0; i < broiChisla; i++)
            {
                int k = int.Parse(Console.ReadLine());
                SumRight += k;
            }
            //for (int i = 0; i < broiChisla*2; i++)
            //{
            //    int k = int.Parse(Console.ReadLine());
            //    if (i<broiChisla)
            //    {
            //        Sumleft += k;
            //    }
            //    else
            //    {
            //        SumRight += k;
            //    }

            //}
            if (Sumleft==SumRight)
            {
                total = SumRight = Sumleft;
                Console.WriteLine("Yes,sum = {0}",total);
            }
            else if (Sumleft !=SumRight)
            {
                diffrence = Math.Abs(Sumleft - SumRight);
                Console.WriteLine("No,diff ={0}",diffrence);
            }
            

            
        }
    }
}
