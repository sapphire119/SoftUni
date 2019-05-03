using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Болница
{
    class Program
    {
        static void Main(string[] args)
        {

            var periodInDays = int.Parse(Console.ReadLine());
            var treatedPatients = 0;
            var untreatedPatients = 0;
            var numberOfDoctors = 7;
            for (int i = 1; i <= periodInDays; i++)
            {
                var numberOfParientsPerDay = int.Parse(Console.ReadLine());

                if (i % 3 == 0 && untreatedPatients > treatedPatients)
                {
                    numberOfDoctors++;
                }

                var treatedPatientsPerDay = Math.Min(numberOfDoctors,numberOfParientsPerDay);
                var untreatedPatientsPerDay =
                    numberOfParientsPerDay -
                    treatedPatientsPerDay;

                treatedPatients += treatedPatientsPerDay;
                untreatedPatients += untreatedPatientsPerDay;
            }
            Console.WriteLine("Treated patients: {0}.", treatedPatients);
            Console.WriteLine("Untreated patients: {0}.", untreatedPatients);
        }
    }
}
