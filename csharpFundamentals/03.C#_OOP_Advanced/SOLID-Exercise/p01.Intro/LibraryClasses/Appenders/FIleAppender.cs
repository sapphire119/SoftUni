using System;
using System.IO;
using System.Text;

public class FileAppender : Appender
{
    public FileAppender(ILayout layout)
        : base(layout)
    {
        this.File = new LogFile();
    }

    public ILog File { get; set; }

    public override void Append(params string[] messages)
    {
        var reportedLevel = Enum.Parse<ReportLevel>(messages[1]);

        if (this.ReportLevel <= reportedLevel)
        {
            string path = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\")) + @"\log.txt";

            string message = this.layout.Format(messages) + Environment.NewLine;

            this.File.Write(newPath, message);

            this.messagesAppended++;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(base.ToString() + $", File size: {this.File.Sum}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}