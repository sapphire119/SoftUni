using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Магазин_за_плодове
{
    class Program
    {
        static void Main(string[] args)
        {

            string fruit = Console.ReadLine().ToLower();
            string Days = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());
            double result;
            
            bool value = (Days == "monday" || Days == "tuesday" || Days == "wednesday" || Days == "thursday" || Days == "friday");
            bool value1 = (Days == "saturday" || Days == "sunday");
            if (value)
            {
                switch (fruit)
                {
                    case "banana": result = quantity * 2.50; Console.WriteLine(result);break;
                    case "apple": result = quantity * 1.20; Console.WriteLine(result); break;
                    case "orange": result = quantity * 0.85; Console.WriteLine(result); break;
                    case "grapefruit": result = quantity * 1.45; Console.WriteLine(result); break;
                    case "kiwi": result = quantity * 2.70; Console.WriteLine(result); break;
                    case "pineapple": result = quantity * 5.50; Console.WriteLine(result); break;
                    case "grapes": result = quantity * 3.85; Console.WriteLine(result); break;

                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (value1)
            {
                switch (fruit)
                {
                    case "banana": result = quantity * 2.70; Console.WriteLine(result); break;
                    case "apple": result = quantity * 1.25; Console.WriteLine(result); break;
                    case "orange": result = quantity * 0.90; Console.WriteLine(result); break;
                    case "grapefruit": result = quantity * 1.60; Console.WriteLine(result); break;
                    case "kiwi": result = quantity * 3.00; Console.WriteLine(result); break;
                    case "pineapple": result = quantity * 5.60; Console.WriteLine(result); break;
                    case "grapes": result = quantity * 4.20; Console.WriteLine(result); break;

                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
