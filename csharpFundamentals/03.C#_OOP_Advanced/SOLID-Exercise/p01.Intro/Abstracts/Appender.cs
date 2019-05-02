using System.Text;

public abstract class Appender : IAppender
{
    protected ILayout layout;
    protected Validator validator;
    protected int messagesAppended;

    protected Appender(ILayout layout)
    {
        this.layout = layout;
        this.validator = new Validator();
        this.ReportLevel = ReportLevel.INFO;
    }

    public ReportLevel ReportLevel { get; set; }

    public abstract void Append(params string[] message);

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, " +
            $"Report level: {this.ReportLevel}, Messages appended: {this.messagesAppended}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}