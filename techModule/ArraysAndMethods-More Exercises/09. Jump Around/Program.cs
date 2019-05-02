using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Jump_Around
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var newIndex = 0;
            var index = 0;
            var sum = array[0];
            var number = array[0];
            var diffrence = 0;
            while (true)
            {
                newIndex = number + index;
                if (newIndex <= (array.Length - 1))
                {
                    number = array[newIndex];
                    index = newIndex;
                    sum += number;
                }
                else if (newIndex > (array.Length - 1))
                {
                    diffrence = index - number;
                    if (diffrence >= 0)
                    {
                        newIndex = diffrence;
                        number = array[newIndex];
                        index = newIndex;
                        sum += number;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
