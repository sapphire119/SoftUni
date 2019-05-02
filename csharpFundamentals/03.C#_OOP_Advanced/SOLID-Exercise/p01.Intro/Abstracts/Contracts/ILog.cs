public interface ILog
{
    void Write(params string[] messages);

    double Sum { get; }
}