using System.IO;
using System.Text;
using System.Linq;
using System;
using System.Text.RegularExpressions;

public class LogFile : ILog
{
    public double Sum { get; private set; }

    public void Write(params string[] messages)
    {
        string path = messages[0];
        string message = messages[1];

        Regex regex = new Regex(@"[a-zA-Z]+");
        var matches = regex.Matches(message);
        foreach (var match in matches)
        {
            this.Sum += match.ToString().ToCharArray().Sum(c => c);
        }

        //this.Sum += message.ToCharArray().Where(c => char.IsLetterOrDigit(c)).Sum(c => c);

        File.AppendAllText(path, message);
    }
}