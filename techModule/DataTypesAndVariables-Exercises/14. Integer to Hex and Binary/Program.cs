using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Превръща 10-тично число във 2чна и 16ча бройна система
            int number = int.Parse(Console.ReadLine());
            string hexademical = Convert.ToString(number, 16);
            string binary = Convert.ToString(number, 2); // convert 5 to its binary representation
            Console.WriteLine(hexademical.ToUpper());
            Console.WriteLine(binary);

        }
    }
}
