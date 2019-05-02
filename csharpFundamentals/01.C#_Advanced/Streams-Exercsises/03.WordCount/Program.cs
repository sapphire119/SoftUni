namespace _03.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {

        //Не видях никъде да го има тоя words.txt файл и го създадох













        public static void Main()
        {
            var wordCount = new Dictionary<string, int>();
            var wordsString = "quick" +
                Environment.NewLine +
                "is" +
                Environment.NewLine +
                "fault";
            var buffer = Encoding.UTF8.GetBytes(wordsString);
            using (var fs = new FileStream("words.txt", FileMode.Create))
            {
                fs.Write(buffer, 0, buffer.Length);
            }

            using (var streamReader = new StreamReader("./../streams/text.txt"))
            {
                var wordsToLookFor = new List<string>();
                using (var anotherStreamReader = new StreamReader("words.txt"))
                {
                    string line;
                    while ((line = anotherStreamReader.ReadLine()) != null)
                    {
                        wordsToLookFor.Add(line);
                    }
                }
                var textToAppend = string.Empty;
                string textLine;
                while ((textLine = streamReader.ReadLine()) != null)
                {
                    textToAppend += textLine.ToLower();
                }

                foreach (var wordToLookFor in wordsToLookFor)
                {
                    int index;
                    while ((index = textToAppend.IndexOf(wordToLookFor)) != -1)
                    {
                        if (!char.IsLetter(textToAppend[index - 1]) || !char.IsLetter(textToAppend[index + 1]))
                        {
                            if (!wordCount.ContainsKey(wordToLookFor))
                            {
                                wordCount[wordToLookFor] = 0;
                            }
                            wordCount[wordToLookFor]++;
                        }
                        textToAppend = textToAppend.Remove(index, wordToLookFor.Length);
                    }
                }
                wordCount = wordCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, p => p.Value);

                using (var streamWriter = new StreamWriter("result.txt"))
                {
                    foreach (var wordAndCount in wordCount)
                    {
                        var word = wordAndCount.Key;
                        var count = wordAndCount.Value;
                        streamWriter.WriteLine($"{word} - {count}");
                    }
                }
            }
        }
    }
}
