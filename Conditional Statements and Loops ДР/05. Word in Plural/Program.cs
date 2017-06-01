using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Word_in_Plural
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower();
            var NewInput = "";
            if (input.EndsWith("y")) // string.EndsWith метод
            {
                NewInput = input.Remove(input.Length - 1); //string.Remove метод
                Console.WriteLine(NewInput + "ies"); 
            }
            else if (input.EndsWith("o") || input.EndsWith("ch") || input.EndsWith("s") || input.EndsWith("sh") || input.EndsWith("x") || input.EndsWith("z"))
            {
                Console.WriteLine(input + "es");
            }
            else
            {
                Console.WriteLine(input + "s");
            }
        }
    }
}
