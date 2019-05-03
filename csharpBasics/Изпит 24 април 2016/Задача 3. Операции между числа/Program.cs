using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_3.Операции_между_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string x = Console.ReadLine();
            double equation = 0;
                switch (x)
                {
                    case "+": equation = n1 + n2; break;
                    case "-": equation = n1 - n2; break;
                    case "*": equation = n1 * n2; break;
                    case "/":
                    if (n2 != 0)
                    {
                        equation = (double) n1 / n2;
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide {0} by zero",n1);
                    }
                    break;
                    case "%":
                    if (n2 != 0)
                    {
                        equation =  n1 % n2;
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide {0} by zero", n1);
                    }
                    break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            if (n2 != 0 && (x=="+" || x=="-" || x=="*" ))
            {                
                if (equation % 2 == 0)
                {
                    Console.WriteLine("{0} {1} {2} = {3} - even", n1, x, n2, equation);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2} = {3} - odd", n1, x, n2, equation);
                }
            }
            else if (n2 !=0 && x=="%")
            {
                Console.WriteLine("{0} {1} {2} = {3}", n1, x, n2, equation);
            }
            else if (n2 != 0 && x == "/")
            {
                Console.WriteLine("{0} {1} {2} = {3:f2}", n1, x, n2, equation);
            }
            
        }
    }
}
