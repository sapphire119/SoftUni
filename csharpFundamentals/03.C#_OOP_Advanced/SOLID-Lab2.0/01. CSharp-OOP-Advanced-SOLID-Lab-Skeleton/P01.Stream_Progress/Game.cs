namespace P01.Stream_Progress
{
    using P01.Stream_Progress.Abstracts;

    public class Game : Data
    {
        public Game(string type, double price ,int length, int bytesSent) 
            : base(length, bytesSent)
        {
            this.Type = type;
            this.Price = price;
        }

        public string Type { get; private set; }

        public double Price { get; private set; }
    }
}
