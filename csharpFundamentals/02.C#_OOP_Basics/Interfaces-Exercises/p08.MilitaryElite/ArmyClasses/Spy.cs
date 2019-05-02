using System.Text;

public class Spy : ISoldier, ISpy
{
    public Spy(int id, string firstName, string lastName, long codeNumber)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.CodeNumber = codeNumber;
    }

    public int Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public long CodeNumber { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}")
            .AppendLine($"Code Number: {this.CodeNumber}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}