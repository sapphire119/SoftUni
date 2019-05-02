using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Vapor_Store
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = double.Parse(Console.ReadLine());

            var temp = "";
            var current = "";
            var spent = 0.0;
            var OutFall_4 = 39.99;
            var CS_OG = 15.99;
            var Zplinter_Zell = 19.99;
            var Honored_2 = 59.99;
            var RoverWatch = 29.99;
            var RoverWatch_Origins_Edition = 39.99;

            while (temp != "Game Time")
            {
                temp = Console.ReadLine();

                if (temp == "OutFall 4")
                {
                    current = temp;
                    if (input < OutFall_4)
                    {
                        if (input == 0.0)
                        {
                            Console.WriteLine("Out of Money!");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                    }
                    else
                    {
                        input = input - OutFall_4;
                        spent += OutFall_4;
                        Console.WriteLine($"Bought {current}");
                    }
                }
                else if (temp == "CS: OG")
                {
                    current = temp;
                    if (input < CS_OG)
                    {
                        if (input == 0.0)
                        {
                            Console.WriteLine("Out of Money!");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                    }
                    else
                    {
                        input = input - CS_OG;
                        spent += CS_OG;
                        Console.WriteLine($"Bought {current}");
                    }
                }
                else if (temp == "Zplinter Zell")
                {
                    current = temp;
                    if (input < Zplinter_Zell)
                    {
                        if (input == 0.0)
                        {
                            Console.WriteLine("Out of Money!");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                    }
                    else
                    {
                        input = input - Zplinter_Zell;
                        spent += Zplinter_Zell;
                        Console.WriteLine($"Bought {current}");
                    }
                }
                else if (temp == "Honored 2")
                {
                    current = temp;
                    if (input < Honored_2)
                    {
                        if (input == 0.0)
                        {
                            Console.WriteLine("Out of Money!");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                    }
                    else
                    {
                        input = input - Honored_2;
                        spent += Honored_2;
                        Console.WriteLine($"Bought {current}");
                    }
                }
                else if (temp == "RoverWatch")
                {
                    current = temp;
                    if (input < RoverWatch)
                    {
                        if (input == 0.0)
                        {
                            Console.WriteLine("Out of Money!");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                    }
                    else
                    {
                        input = input - RoverWatch;
                        spent += RoverWatch;
                        Console.WriteLine($"Bought {current}");
                    }
                }
                else if (temp == "RoverWatch Origins Edition")
                {
                    current = temp;
                    if (input < RoverWatch_Origins_Edition)
                    {
                        if (input == 0.0)
                        {
                            Console.WriteLine("Out of Money!");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                    }
                    else
                    {
                        input = input - RoverWatch_Origins_Edition;
                        spent += RoverWatch_Origins_Edition;
                        Console.WriteLine($"Bought {current}");
                    }
                }
                else
                {
                    if (temp=="Game Time")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                        continue;
                    }
                }
            }
            if (input ==0.0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine("Total spent: ${0:f2}. Remaining: ${1:f2}",spent,input);
            }
        }
    }
}
