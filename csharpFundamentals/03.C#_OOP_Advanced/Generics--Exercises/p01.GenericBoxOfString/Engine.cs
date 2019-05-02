public class Engine
{
    private readonly Reader reader;
    private readonly Writer writer;

    public Engine()
    {
        this.reader = new Reader();
        this.writer = new Writer();
    }

    public void Run()
    {
        var lines = int.Parse(reader.ReadLine());

        for (int count = 0; count < lines; count++)
        {
            var input = reader.ReadLine();

            Box<string> box = new Box<string>(input);

            writer.WriteLine(box);
        }
    }
}