using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.SMS_Typing
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var temp = "";
            var word = "";
            for (int i = 1; i <= input; i++)
            {
                var number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 2:temp = "a";break;
                    case 22:temp = "b";break;
                    case 222:temp = "c";break;
                    case 3: temp = "d"; break;
                    case 33: temp = "e"; break;
                    case 333: temp = "f"; break;
                    case 4: temp = "g"; break;
                    case 44: temp = "h"; break;
                    case 444: temp = "i"; break;
                    case 5: temp = "j"; break;
                    case 55: temp = "k"; break;
                    case 555: temp = "l"; break;
                    case 6: temp = "m"; break;
                    case 66: temp = "n"; break;
                    case 666: temp = "o"; break;
                    case 7: temp = "p"; break;
                    case 77: temp = "q"; break;
                    case 777: temp = "r"; break;
                    case 7777: temp = "s"; break;
                    case 8: temp = "t"; break;
                    case 88: temp = "u"; break;
                    case 888: temp = "v"; break;
                    case 9: temp = "w"; break;
                    case 99: temp = "x"; break;
                    case 999: temp = "y"; break;
                    case 9999: temp = "z"; break;
                    case 0:temp = " ";break;
                    default:
                        break;
                }
                word += temp;
            }
            Console.WriteLine(word);
        }
    }
}
