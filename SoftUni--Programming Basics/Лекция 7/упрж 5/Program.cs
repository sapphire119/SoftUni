using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace упрж_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //12

            //Въвеждай нещо си ,докато то е РАЗЛИЧНО  от 12
            string input;
            do
            {
                Console.WriteLine("Vuvedi");
                input = Console.ReadLine();
                Console.WriteLine(input);
            }
            while (input != "12");
        }
    }
}
