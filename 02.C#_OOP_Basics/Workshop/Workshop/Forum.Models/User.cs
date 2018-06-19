using System.Collections.Generic;

public class User
{
    public User(int id, string username, string password)
    {
        this.Id = id;
        this.Username = username;
        this.Password = password;
    }

    public User(int id, string username, string password, ICollection<int> posts)
        : this(id, username, password)
    {
        this.Posts = new List<int>(posts);
    }

    public int Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public ICollection<int> Posts { get; set; } = new List<int>();
}