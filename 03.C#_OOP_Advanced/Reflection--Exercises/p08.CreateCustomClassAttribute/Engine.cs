using System.Linq;

public class Engine
{
    private readonly IWriteable writer;
    private readonly IReadable reader;

    public Engine(IWriteable writeable, IReadable readable)
    {
        this.writer = writeable;
        this.reader = readable;
    }

    public void Run()
    {
        var type = typeof(Weapon);

        var customAttribute = (SoftUniAttribute)type.GetCustomAttributes(typeof(SoftUniAttribute), false).FirstOrDefault();

        string command;
        while ((command = reader.ReadLine()) != "END")
        {
            switch (command)
            {
                case "Author": this.writer.WriteLine($"Author: {customAttribute.Author}"); break;
                case "Revision": this.writer.WriteLine($"Revision: {customAttribute.Revisions}"); break;
                case "Description": this.writer.WriteLine($"Class description: {customAttribute.Description}"); break;
                case "Reviewers": this.writer.WriteLine($"Reviewers: {string.Join(", ", customAttribute.Reviewers)}"); break;
            }
        }
    }
}