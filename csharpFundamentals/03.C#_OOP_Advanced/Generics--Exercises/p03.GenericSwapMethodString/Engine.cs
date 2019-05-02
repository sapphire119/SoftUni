using System;
using System.Linq;
using System.Collections.Generic;

public class Engine
{
    private readonly Reader reader;
    private readonly Writer writer;
    private readonly Swapper swapper;

    public Engine()
    {
        this.reader = new Reader();
        this.writer = new Writer();
        this.swapper = new Swapper();
    }

    public void Run()
    {
        var lines = int.Parse(reader.ReadLine());

        var boxes = new List<Box<string>>();

        for (int count = 0; count < lines; count++)
        {
            var input = reader.ReadLine();

            Box<string> box = new Box<string>(input);

            //writer.WriteLine(box);

            boxes.Add(box);
        }

        var swapNumbers = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        this.swapper.Swap(boxes, swapNumbers);

        writer.WriteLine(string.Join(Environment.NewLine, boxes));
    }
}