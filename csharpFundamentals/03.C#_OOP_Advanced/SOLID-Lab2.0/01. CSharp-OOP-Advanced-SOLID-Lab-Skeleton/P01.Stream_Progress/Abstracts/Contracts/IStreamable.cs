namespace P01.Stream_Progress.Abstracts.Contracts
{
    public interface IStreamable
    {
        int Length { get; }

        int BytesSent { get; }
    }
}