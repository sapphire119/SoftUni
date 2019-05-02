namespace _01.first
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var costOFBullets = int.Parse(Console.ReadLine());

            var sizeOfGunBarrel = int.Parse(Console.ReadLine());

            var bullets = Console.ReadLine().Split().Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToArray();

            var locks = Console.ReadLine().Split().Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToArray();

            var valueOfIntelligence = int.Parse(Console.ReadLine());

            var bulletsStack = new Stack<int>();

            var lockQueue = new Queue<int>();

            foreach (var bullet in bullets)
            {
                bulletsStack.Push(bullet);
            }

            foreach (var @lock in locks)
            {
                lockQueue.Enqueue(@lock);
            }

            var shotsFired = 0;
            while (lockQueue.Count != 0 && bulletsStack.Count != 0)
            {
                for (int shotCount = 1; shotCount <= sizeOfGunBarrel; shotCount++)
                {
                    if (!bulletsStack.Any())
                    {
                        break;
                    }
                    var currentBullet = bulletsStack.Pop();
                    var currentLock = lockQueue.Peek();

                    if (currentBullet <= currentLock)
                    {
                        lockQueue.Dequeue();
                        Console.WriteLine("Bang!");
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }
                    shotsFired++;
                    if (shotCount == sizeOfGunBarrel && bulletsStack.Count != 0)
                    {
                        Console.WriteLine("Reloading!");
                    }
                    if (!lockQueue.Any())
                    {
                        break;
                    }
                }
            }

            if (lockQueue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
            }
            else
            {
                var result = valueOfIntelligence - (shotsFired * costOFBullets);
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${result}");
            }

        }
    }
}
