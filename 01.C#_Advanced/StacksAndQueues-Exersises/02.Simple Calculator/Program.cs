namespace _02.Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<string>();

            var numbersAndOperators = input.Split(' ').Where(n => !string.IsNullOrWhiteSpace(n)).ToArray();


            for (int i = numbersAndOperators.Length - 1; i >= 0; i--) 
            {
                stack.Push(numbersAndOperators[i]);
            }


            var operant = string.Empty;
            var result = 0;
            while (stack.Count != 0)
            {
                var numberOrOperant = stack.Pop();
                var isItAnumber = int.TryParse(numberOrOperant, out int number);

                if (!isItAnumber)
                {
                    operant = numberOrOperant;
                }
                else
                {
                    if (operant != string.Empty)
                    {
                        switch (operant)
                        {
                            case "+": result += number; operant = string.Empty; break;
                            case "-": result -= number; operant = string.Empty; break;
                            default:
                                operant = string.Empty;
                                break;
                        } 
                    }
                    else
                    {
                        result += number;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
