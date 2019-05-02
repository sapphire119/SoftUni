using System;

public class Engine
{
    private readonly IReadable reader;
    private readonly IWriteable writer;

    public Engine(IReadable readable, IWriteable writeable)
    {
        this.reader = readable;
        this.writer = writeable;
    }

    public void Run()
    {
        string input = this.reader.ReadLine();

        string[] inputArgs = input.Split();

        var combinationsCount = int.Parse(this.reader.ReadLine());

        ChangeTrafficLights(inputArgs);

        for (int count = 0; count < combinationsCount; count++)
        {
            this.writer.WriteLine(string.Join(" ", inputArgs));
            ChangeTrafficLights(inputArgs);
        }
    }

    private void ChangeTrafficLights(string[] inputArgs)
    {
        for (int count = 0; count < inputArgs.Length; count++)
        {
            switch (inputArgs[count])
            {
                case "Red": inputArgs[count] = "Green"; break;
                case "Yellow": inputArgs[count] = "Red"; break;
                case "Green": inputArgs[count] = "Yellow";break;
            }
        }
    }
}