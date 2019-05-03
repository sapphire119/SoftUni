using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Квартално_магазинче
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double result = 0;
            double quantity = double.Parse(Console.ReadLine());

            if (city =="Sofia")
            {
                switch (product)
                {        
                    case "coffee":result = quantity * 0.50;  Console.WriteLine(result);
                        break; 
                    case "beer":result = quantity * 1.20;    Console.WriteLine(result);
                        break; 
                    case "water":result = quantity * 0.80;   Console.WriteLine(result);
                        break;
                    case "sweets":result = quantity * 1.45;  Console.WriteLine(result);
                        break;
                    case "peanuts":result = quantity * 1.60; Console.WriteLine(result);
                        break;

                    default:
                        Console.WriteLine("Error");break;

                }
            }           
            else if (city =="Varna")
            {
                switch (product)
                {

                    case "coffee": result = quantity * 0.45; Console.WriteLine(result);
                        break;
                    case "beer": result = quantity * 1.10;  Console.WriteLine(result);
                        break;
                    case "water": result = quantity * 0.70; Console.WriteLine(result);
                        break;
                    case "sweets": result = quantity * 1.35;Console.WriteLine(result);
                        break;
                    case "peanuts": result = quantity * 1.55; Console.WriteLine(result);
                        break;
                    default:
                        Console.WriteLine("Error"); break;
                }   
            }
            else if (city == "Plovdiv")
            {
                switch (product)
                {

                    case "coffee": result = quantity * 0.40; Console.WriteLine(result);
                        break;
                    case "water": result = quantity * 0.70; Console.WriteLine(result);
                        break;
                    case "beer": result = quantity * 1.15;  Console.WriteLine(result);
                        break;
                    case "sweets": result = quantity * 1.30; Console.WriteLine(result);
                        break;
                    case "peanuts": result = quantity * 1.50; Console.WriteLine(result);
                        break;
                    default:
                        Console.WriteLine("Error"); break;
                }
            }

        }
    }
}
