namespace _03._Crypto_Blockchain
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            var regex = @"(?<firstString>\[[^0-9]*(?<firstNumbers>\d{3,})[^0-9]*\])|(?<secondString>\{[^0-9]*(?<secondNumbers>\d{3,})[^0-9]*\})";

            var sb = new StringBuilder();
            for (int count = 0; count < lines; count++)
            {
                var inputLine = Console.ReadLine();
                sb.Append(inputLine);
            }

            var fullMessage = sb.ToString();

            var matches = Regex.Matches(fullMessage,regex);

            var result = string.Empty;
            foreach (Match match in matches)
            {
                var secondMatch = Regex.Match(match.Value, @"\d+");
                if (!(secondMatch.Length % 3 == 0))
                {
                    continue;
                }
                var numbers = secondMatch.Value;
                while (numbers.Length != 0)
                {
                    var currentNumbers = string.Empty;
                    for (int index = 0; index < 3; index++)
                    {
                        currentNumbers += numbers[0];
                        numbers = numbers.Substring(1);
                    }
                    var currentNumber = int.Parse(currentNumbers) - match.Length;
                    result += Convert.ToChar(currentNumber);
                }
            }

            Console.WriteLine(result);
        }
    }
}
