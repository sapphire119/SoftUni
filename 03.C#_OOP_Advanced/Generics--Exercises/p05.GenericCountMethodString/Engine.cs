using System;
using System.Linq;
using System.Collections.Generic;

public class Engine
{
    private readonly Reader reader;
    private readonly Writer writer;
    private readonly Swapper swapper;
    private readonly Comparer comparer;

    public Engine()
    {
        this.reader = new Reader();
        this.writer = new Writer();
        this.swapper = new Swapper();
        this.comparer = new Comparer();
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

        var valueToCompare = new Box<string>(reader.ReadLine());

        this.writer.WriteLine(this.comparer.Compare(boxes, valueToCompare));
    }
}