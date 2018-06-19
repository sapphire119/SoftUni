namespace P01.Stream_Progress.Abstracts
{
    using P01.Stream_Progress.Abstracts.Contracts;

    public abstract class Data : IStreamable
    {
        protected Data(int length, int bytesSent)
        {
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }
    }
}
