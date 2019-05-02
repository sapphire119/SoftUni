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
            var textReplace = string.Empty;
            var index = 0;
            var message = string.Empty;
            var distinct = string.Empty;
            var input = string.Empty;
            while (input != "END") 
            {
                input = Console.ReadLine();
                textReplace = input.Split().First();
                if (input == "Distinct")
                {
                    array = array.Distinct().ToArray();
                }
                else if (input == "Reverse")
                {
                    array = array.Reverse().ToArray();
                }
                else if (textReplace == "Replace")
                {
                    index = int.Parse(input.Split().ElementAt(1));
                    if (!(0 <= index && index < array.Length))
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        message = input.Split().Last();
                        array[index] = message;
                    }
                }
                else if (input !="END")
                {
                    Console.WriteLine("Invalid input!");
                }
                 
            }
            Console.WriteLine(string.Join(", ", array));


        }
    }
}
