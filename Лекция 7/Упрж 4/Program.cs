using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace упр_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int MaxNumber= int.Parse(Console.ReadLine());

            int firstNumber = 1;

            while (firstNumber <= MaxNumber) //Start button ^^^^^^^^^^^^^^ +Enter (За да влезем в режим
                //          на дебъгване !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!     )
            {
                Console.WriteLine("{0}",firstNumber);
                firstNumber = 2 * firstNumber + 1;
            }

        }
        
    }
}
