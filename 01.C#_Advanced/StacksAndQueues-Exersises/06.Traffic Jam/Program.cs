namespace _06.Traffic_Jam
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfCarsThatCanPass = int.Parse(Console.ReadLine());
            var command = Console.ReadLine();

            var queOfCars = new Queue<string>();

            var numberOfCarsThatHavePassed = 0;
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < numberOfCarsThatCanPass; i++)
                    {
                        if (queOfCars.Count != 0)
                        {
                            Console.WriteLine($"{queOfCars.Dequeue()} passed!");
                            numberOfCarsThatHavePassed += 1; 
                        }
                    }
                }
                else
                {
                    queOfCars.Enqueue(command);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"{numberOfCarsThatHavePassed} cars passed the crossroads.");
        }
    }
}
