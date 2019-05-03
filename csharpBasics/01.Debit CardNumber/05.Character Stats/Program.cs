using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();

            var CurrentHealth = int.Parse(Console.ReadLine());
            var MaxHealth = int.Parse(Console.ReadLine());
            var CurrentEnergy = int.Parse(Console.ReadLine());
            var MaxEnergy = int.Parse(Console.ReadLine());

            var dotsHPtoPrint = MaxHealth - CurrentHealth;
            var dotsENEtoPrint = MaxEnergy - CurrentEnergy;
            Console.WriteLine($"Name: {name}");
            Console.WriteLine("Health: |{0}{1}|",
                new string('|',CurrentHealth),
                new string('.',dotsHPtoPrint));
            Console.WriteLine("Energy: |{0}{1}|",
                new string('|', CurrentEnergy),
                new string('.',dotsENEtoPrint));

        }
    }
}
