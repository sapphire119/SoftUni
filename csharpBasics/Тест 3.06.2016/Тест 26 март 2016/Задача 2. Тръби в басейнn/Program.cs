using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_2.Тръби_в_басейнn
{
    class Program
    {
        static void Main(string[] args)
        {

            int broi = int.Parse(Console.ReadLine());
            int broqch1 = 0; 
            int broqch2 = 0;
            int broqch3 = 0;
            double procent1 = 0;
            double procent2 = 0;
            double procent3 = 0;


            for (int i = 1; i <=broi; i++)
            {

                int k = int.Parse(Console.ReadLine());

                if (k % 2 == 0)
                {
                    broqch1 += 1;
                    

                    
                }

                if (k % 3 == 0) 
                {
                    broqch2 += 1;
                    
                    
                }

                if (k % 4 == 0)
                {
                    broqch3 += 1;
                    
                }
                
                if (i==broi)
                {
                    procent1 = (double)(broqch1 * 100) / broi;
                    procent2 = (double) (broqch2 * 100) / broi;
                    procent3 = (double) (broqch3 * 100) / broi;
                    Console.WriteLine("{0:f2}%",procent1);
                    Console.WriteLine("{0:f2}%", procent2);
                    Console.WriteLine("{0:f2}%", procent3);
                }

            }
            
            
            


        }
    }
}
