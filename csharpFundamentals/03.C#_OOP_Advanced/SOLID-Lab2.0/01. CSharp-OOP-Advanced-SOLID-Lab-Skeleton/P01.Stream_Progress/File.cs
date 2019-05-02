namespace P01.Stream_Progress
{
    using P01.Stream_Progress.Abstracts;

    public class File : Data
    {
        public File(string name, int length, int bytesSent)
            :base(length, bytesSent)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
