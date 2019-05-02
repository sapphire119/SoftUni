public interface IAppender
{
    void Append(params string[] message);

    ReportLevel ReportLevel { get; set; }
}