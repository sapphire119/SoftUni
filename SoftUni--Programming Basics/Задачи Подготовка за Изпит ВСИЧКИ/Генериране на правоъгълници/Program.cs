using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Генериране_на_правоъгълници
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());

            int diffrence = 0;
            

            for (int i = -number; i <= number; i++)
            {
                for (int j = -number; j <= number; j++)
                {
                    for (int k = number; i < k; k--) 
                    {
                        for (int p = number; j < p; p--)  
                        {
                                diffrence = (j-i) * (p-k);

                                if (diffrence >= area) 
                                {                    //left      //right
                                    Console.WriteLine("({0}, {1}) ({2}, {3}) -> {4}",i,k,j,p,diffrence);
                                }
                            
                        }
                    }
                }
            }


        }
    }
}
