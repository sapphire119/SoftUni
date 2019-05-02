using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Manipulate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split().ToArray();
            var numberOfLines = int.Parse(Console.ReadLine());
            var textReplace = string.Empty;
            var index = 0;
            var message = string.Empty;
            var distinct = string.Empty;
            for (int i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine();
                if (input == "Distinct")
                {
                    array = array.Distinct().ToArray();
                }
                else if (input == "Reverse")
                {
                    array = array.Reverse().ToArray();
                }
                textReplace = input.Split().First();
                if (textReplace == "Replace")
                {
                    index = int.Parse(input.Split().ElementAt(1));
                    message = input.Split().Last();
                    array[index] = message;
                }
            }
            Console.WriteLine(string.Join(", ",array));


        }
    }
}
