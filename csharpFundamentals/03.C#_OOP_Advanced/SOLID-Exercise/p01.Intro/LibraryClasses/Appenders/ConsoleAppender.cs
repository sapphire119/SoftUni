using System;

public class ConsoleAppender : Appender
{
    public ConsoleAppender(ILayout layout)
        : base(layout) { }

    public override void Append(params string[] arguments)
    {
        var reportedLevel = Enum.Parse<ReportLevel>(arguments[1]);

        if (this.ReportLevel <= reportedLevel)
        {
            Console.WriteLine(this.layout.Format(arguments));
            messagesAppended++;
        }
    }
}