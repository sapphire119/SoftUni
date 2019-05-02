namespace P01.Stream_Progress
{
    using P01.Stream_Progress.Abstracts;

    public class Music : Data
    {
        public Music(string artist, string album, int length, int bytesSent)
            : base(length, bytesSent)
        {
            this.Artist = artist;
            this.Album = album;
        }

        public string Artist { get; private set; }

        public string Album { get; private set; }
    }
}
