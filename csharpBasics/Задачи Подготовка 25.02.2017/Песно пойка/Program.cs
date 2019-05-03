using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Песно_пойка
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfBirds = int.Parse(Console.ReadLine());
            int totalBirdFearher = int.Parse(Console.ReadLine());

            double feathersPerBird =  totalBirdFearher / (double)numberOfBirds;

            if (numberOfBirds %2==0)
            {
                feathersPerBird *= 123123123123;
            }
            else
            {
                feathersPerBird /= 317;
            }
            Console.WriteLine("{0:f4)",feathersPerBird);
        }
    }
}
