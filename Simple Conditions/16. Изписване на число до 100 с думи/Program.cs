using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int inputLenght = input.Length;//vzima duljinata na stringa
            if (inputLenght == 1)
            {
                switch (input)
                {
                    case "0": Console.WriteLine("zero"); break;
                    case "1": Console.WriteLine("one"); break;
                    case "2": Console.WriteLine("two"); break;
                    case "3": Console.WriteLine("three"); break;
                    case "4": Console.WriteLine("four"); break;
                    case "5": Console.WriteLine("five"); break;
                    case "6": Console.WriteLine("six"); break;
                    case "7": Console.WriteLine("seven"); break;
                    case "8": Console.WriteLine("eight"); break;
                    case "9": Console.WriteLine("nine"); break;
                    default: Console.WriteLine("invalid number"); break;
                }
            }
            else if (input == "100")
            {
                Console.WriteLine("one hundred");
            }
            else if (inputLenght == 2 && input[0] != '-')
            {
                var Numb1 = "";
                var Numb2 = "";
                if (input[0] == '1')
                {
                    switch (input)
                    {
                        case "10": Console.WriteLine("ten"); break;
                        case "11": Console.WriteLine("eleven"); break;
                        case "12": Console.WriteLine("twelve"); break;
                        case "13": Console.WriteLine("thirteen"); break;
                        case "14": Console.WriteLine("fourteen"); break;
                        case "15": Console.WriteLine("fifteen"); break;
                        case "16": Console.WriteLine("sixteen"); break;
                        case "17": Console.WriteLine("seventeen"); break;
                        case "18": Console.WriteLine("eightteen"); break;
                        case "19": Console.WriteLine("nineteen"); break;
                    }
                }
                else
                {
                    switch (input[0])//23
                    {

                        case '2': Numb1 = "twenty"; break;
                        case '3': Numb1 = "thirty"; break;
                        case '4': Numb1 = "fourty"; break;
                        case '5': Numb1 = "fifty"; break;
                        case '6': Numb1 = "sixty"; break;
                        case '7': Numb1 = "seventy"; break;
                        case '8': Numb1 = "eighty"; break;
                        case '9': Numb1 = "ninety"; break;
                    }
                    switch (input[1])
                    {
                        case '0': Numb2 = ""; break;
                        case '1': Numb2 = "one"; break;
                        case '2': Numb2 = "two"; break;
                        case '3': Numb2 = "three"; break;
                        case '4': Numb2 = "four"; break;
                        case '5': Numb2 = "five"; break;
                        case '6': Numb2 = "six"; break;
                        case '7': Numb2 = "seven"; break;
                        case '8': Numb2 = "eight"; break;
                        case '9': Numb2 = "nine"; break;
                    }

                    if (Numb2 != "")
                    {
                        Console.WriteLine(Numb1 + " " + Numb2);
                    }
                    else
                    {
                        Console.WriteLine(Numb1);
                    }

                }

            }
            else
            {
                Console.WriteLine("invalid number");
            }

        }
    }
}