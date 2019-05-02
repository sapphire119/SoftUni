namespace _01.Regeh
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var regex = (@"\[\w+\<\d+(REGEH)\d+\>\w+\]");
            var input = Console.ReadLine();

            var matches = Regex.Matches(input, regex);

            var secondPatter = @"\<(?<number1>\d+)REGEH(?<number2>\d+)\>";

            var indexes = new List<int>();

            foreach (Match match in matches)
            {
                var secondMatches = Regex.Matches(match.Value, secondPatter);
                foreach (Match secondMatch in secondMatches)
                {
                    var firstNumber = secondMatch.Groups["number1"].Value;
                    var secondNumber = secondMatch.Groups["number2"].Value;
                    indexes.Add(int.Parse(firstNumber));
                    indexes.Add(int.Parse(secondNumber));
                }
            }
            var sumIndex = 0;
            var result = string.Empty;
            foreach (var index in indexes)
            {
                sumIndex += index;
                if (sumIndex > input.Length - 1)
                {
                    sumIndex -= input.Length - 1;
                }
                result += input[sumIndex];
            }
            Console.WriteLine(result);
        }
    }
}
