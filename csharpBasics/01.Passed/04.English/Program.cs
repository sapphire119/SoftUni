using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.English
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "usa":
                case "england":
                    Console.WriteLine("English"); break;

                case "spain":
                case "argentina":
                case "mexico":
                    Console.WriteLine("Spanish");break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
