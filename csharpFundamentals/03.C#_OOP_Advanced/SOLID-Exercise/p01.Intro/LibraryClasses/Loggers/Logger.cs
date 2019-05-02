using System.Collections.Generic;

public class Logger : ILogger
{
    private IAppender[] appenders;

    public Logger(params IAppender[] appenders)
    {
        this.appenders = appenders;
    }

    public IReadOnlyCollection<IAppender> GetAppenders => this.appenders;

    public void Log(string date, string reportLevel, string message)
    {
        foreach (var appender in this.appenders)
        {
            appender.Append(date, reportLevel, message);
        }
    }
}