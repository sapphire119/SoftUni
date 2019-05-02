using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            char charValue = '0';
            for (int i = numOne; i <= numTwo; i++)
            {
                charValue = Convert.ToChar(i);
                Console.Write("{0} ",charValue);
            }
        }
    }
}
