using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Neighbour_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var healthGosho = 100.0;
            var healthPesho = 100.0;
            var iterator = 0.0;



            do
            {
                iterator++;
                if (iterator % 2 != 0)
                {
                    healthGosho -= firstNumber;
                    if (healthGosho <= 0.0)
                    {
                        break;
                    }
                    Console.Write("Pesho used Roundhouse kick and reduced");
                    Console.WriteLine(" Gosho to {0} health.", healthGosho);
                    
                }
                else
                {
                    healthPesho -= secondNumber;
                    if (healthPesho <= 0.0)
                    {
                        break;
                    }
                    Console.Write("Gosho used Thunderous fist and reduced");
                    Console.WriteLine(" Pesho to {0} health.", healthPesho);
                    
                }
                if (iterator % 3 == 0)
                {
                    healthGosho += 10;
                    healthPesho += 10;
                }
            } while (healthPesho > 0 || healthGosho > 0);       
            
            if (healthPesho <=0.0 )
            {
                Console.WriteLine($"Gosho won in {iterator}th round.");
            }
            else if(healthGosho <=0.0)
            {
                Console.WriteLine($"Pesho won in {iterator}th round.");
            }

        }
    }
}
