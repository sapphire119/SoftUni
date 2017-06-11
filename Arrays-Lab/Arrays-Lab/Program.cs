using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Lab
{
    class Program
    {
        static void Main(string[] args) //Масив от string-ове
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            for (int i = 0; i < n; i++) 
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Това са числата отзад напред");
            for (int i = n-1; i >= 0; i--) 
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
