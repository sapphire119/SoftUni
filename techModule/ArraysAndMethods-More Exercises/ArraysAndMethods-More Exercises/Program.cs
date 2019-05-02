using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndMethods_MoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var minimum = array.Min();
            var maximum = array.Max();
            var sum = array.Sum();
            var average = array.Average();
            Console.WriteLine(
                "Min = " + minimum +
                "\nMax = " + maximum +
                "\nSum = " + sum +
                "\nAverage = " + average);

        }
    }
}
