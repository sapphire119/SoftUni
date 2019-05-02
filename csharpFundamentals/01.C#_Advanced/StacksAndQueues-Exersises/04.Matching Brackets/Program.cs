namespace _04.Matching_Brackets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var equations = new Stack<string>();
            var usedIndexes = new Stack<int>();

            var startIndex = 0;
            var endIndex = 0;
            //var index = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    startIndex = i;
                    if (!usedIndexes.Contains(startIndex))
                    {
                        var matchedIndex = startIndex;

                        var equationToAdd = string.Empty;
                        while (true)
                        {
                            var elementToAdd = input[matchedIndex].ToString();
                            equationToAdd += elementToAdd;

                            if (elementToAdd == "(" && startIndex != matchedIndex && !usedIndexes.Contains(matchedIndex))
                            {
                                startIndex = matchedIndex;
                                equationToAdd = string.Empty;
                                continue;
                            }
                            if (elementToAdd == ")" && !usedIndexes.Contains(matchedIndex))
                            {
                                endIndex = matchedIndex;
                                break;
                            }
                            matchedIndex++;
                        }
                        equations.Push(equationToAdd);
                        usedIndexes.Push(startIndex);
                        usedIndexes.Push(endIndex);
                        i = -1;
                    }
                }
            }

            var endResult = new Stack<string>();
            while (equations.Count != 0)
            {
                endResult.Push(equations.Pop());
            }

            if (endResult.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, endResult)); 
            }
        }
    }
}

