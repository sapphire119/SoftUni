using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {


            string product = Console.ReadLine();

            switch (product)
            {
                case "apple":
                case "banana":
                case "grapes":
                case "cherry":
                case "lemon":
                case "kiwi":

                    Console.WriteLine("fruit");
                    break;
                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot":
                    Console.WriteLine("vegetable");
                    break;
                default:
                    Console.WriteLine("Unknown");
                    break;

            }




        }
    }
}
