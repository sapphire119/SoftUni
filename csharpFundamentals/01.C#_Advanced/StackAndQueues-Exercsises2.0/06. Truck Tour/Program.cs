namespace _06._Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numberOfPetrolStations = int.Parse(Console.ReadLine());

            var queue = new Queue<int[]>();

            for (int i = 0; i < numberOfPetrolStations; i++)
            {
                var pump = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
                queue.Enqueue(pump);
            }

            for (int currentStart = 0; currentStart < numberOfPetrolStations; currentStart++)
            {
                int fuel = 0;
                bool isSolution = true;

                for (int pumpsPassed = 0; pumpsPassed < numberOfPetrolStations; pumpsPassed++)
                {
                    var currentPump = queue.Dequeue();

                    var pumpFuel = currentPump[0];
                    var nextPumpDistance = currentPump[1];

                    queue.Enqueue(currentPump);

                    fuel += pumpFuel - nextPumpDistance;
                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        isSolution = false;
                        break;
                    }
                }

                if (isSolution)
                {
                    Console.WriteLine(currentStart);
                    Environment.Exit(0);
                }
            }

        }
    }
}
