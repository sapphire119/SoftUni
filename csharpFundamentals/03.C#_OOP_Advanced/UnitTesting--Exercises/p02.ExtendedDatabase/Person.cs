public class Person : IPerson
{
    private long id;
    private string username;

    public Person(long id, string username)
    {
        this.id = id;
        this.username = username;
    }

    public long Id => this.id;

    public string Username => this.username;
}