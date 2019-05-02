using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Inventory_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringArray = Console.ReadLine().Split().ToArray();
            var longArray = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var decimalArray = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            var input = string.Empty;
            while (input !="done")
            {
                input = Console.ReadLine();
                for (int i = 0; i < stringArray.Length; i++)
                {
                    if (input==stringArray[i])
                    {
                        Console.WriteLine("{0} costs: {1}; Available quantity: {2}",
                            stringArray[i],
                            decimalArray[i],
                            longArray[i]);
                    }
                }
            }
        }
    }
}
