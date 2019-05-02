using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class DataMapper
{
    private const string DATA_PATH = "../data/";
    private const string CONFIG_PATH = "config.ini";
    private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";
    private static readonly Dictionary<string, string> config;

    static DataMapper()
    {
        Directory.CreateDirectory(DATA_PATH);
        config = LoadConfig(DATA_PATH + CONFIG_PATH);
    }

    public static List<Reply> LoadReplies()
    {
        List<Reply> replies = new List<Reply>();
        var dataLines = ReadLines(config["replies"]);

        foreach (var line in dataLines)
        {
            var tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
            var id = int.Parse(tokens[0]);
            var content = tokens[1];
            var authorId = int.Parse(tokens[2]);
            var postId = int.Parse(tokens[3]);

            var existingReply = replies.Find(c => c.Id == id);
            if (existingReply == null)
            {
                existingReply = new Reply(id, content, authorId, postId);
                replies.Add(existingReply);
            }
        }

        return replies;
    }

    public static void SaveReplies(List<Reply> replies)
    {
        List<string> lines = new List<string>();

        foreach (var reply in replies)
        {
            const string categoryFormat = "{0};{1};{2};{3}";
            string line = string.Format(categoryFormat,
                reply.Id,
                reply.Content,
                reply.AuthorId,
                reply.PostId);

            lines.Add(line);
        }

        WriteLines(config["replies"], lines.ToArray());
    }

    public static List<Post> LoadPosts()
    {
        List<Post> posts = new List<Post>();
        var dataLines = ReadLines(config["posts"]);

        foreach (var line in dataLines)
        {
            var tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
            var id = int.Parse(tokens[0]);
            var title = tokens[1];
            var content = tokens[2];
            var categoryId = int.Parse(tokens[3]);
            var authorId = int.Parse(tokens[4]);

            var existingPost = posts.Find(c => c.Id == id);
            if (existingPost == null)
            {
                if (tokens.Length > 5)
                {
                    var repliyIds = tokens[5]
                                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                    existingPost = new Post(id, title, content, categoryId, authorId, repliyIds); 
                }
                else
                {
                    existingPost = new Post(id, title, content, categoryId, authorId);
                }
                posts.Add(existingPost);
            }
            //var existingUser = users.Find(c => c.Id == id);
            //if (existingUser == null)
            //{
            //    if (tokens.Length > 3)
            //    {
            //        var postIds = tokens[3]
            //            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            //            .Select(int.Parse)
            //            .ToArray();

            //        existingUser = new User(id, username, password, postIds);
            //    }
            //    else
            //    {
            //        existingUser = new User(id, username, password);
            //    }
            //    users.Add(existingUser);
            //}
        }

        return posts;
    }

    public static void SavePosts(List<Post> posts)
    {
        List<string> lines = new List<string>();

        foreach (var post in posts)
        {
            const string categoryFormat = "{0};{1};{2};{3};{4};{5}";
            string line = string.Format(categoryFormat,
                post.Id,
                post.Title,
                post.Content,
                post.CategoryId,
                post.AuthorId,
                string.Join(",", post.Replies)
                );

            lines.Add(line);
        }

        WriteLines(config["posts"], lines.ToArray());
    }

    public static List<User> LoadUsers()
    {
        List<User> users = new List<User>();
        var dataLines = ReadLines(config["users"]);

        foreach (var line in dataLines)
        {
            if (line.StartsWith(@"\"))
            {

            }
            var tokens = line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var id = int.Parse(tokens[0]);
            var username = tokens[1];
            var password = tokens[2];

            var existingUser = users.Find(c => c.Id == id);
            if (existingUser == null)
            {
                if (tokens.Length > 3)
                {
                    var postIds = tokens[3]
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    existingUser = new User(id, username, password, postIds);
                }
                else
                {
                    existingUser = new User(id, username, password);
                }
                users.Add(existingUser);
            }
        }

        return users;
    }

    public static void SaveUsers(List<User> users)
    {
        List<string> lines = new List<string>();

        foreach (var user in users)
        {
            const string categoryFormat = "{0};{1};{2};{3}";
            string line = string.Format(categoryFormat,
                user.Id,
                user.Username,
                user.Password,
                string.Join(",", user.Posts)
                );

            lines.Add(line);
        }

        WriteLines(config["users"], lines.ToArray());
    }

    public static List<Category> LoadCategories()
    {
        List<Category> categories = new List<Category>();
        var dataLines = ReadLines(config["categories"]);

        foreach (var line in dataLines)
        {
            var tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
            var id = int.Parse(tokens[0]);
            var name = tokens[1];

            var existingCategory = categories.Find(c => c.Id == id);
            if (existingCategory == null)
            {
                if (tokens.Length > 2)
                {
                    var postIds = tokens[2]
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    existingCategory = new Category(id, name, postIds);
                }
                else
                {
                    existingCategory = new Category(id, name);
                }
                categories.Add(existingCategory);
            }
            //var existingUser = users.Find(c => c.Id == id);
            //if (existingUser == null)
            //{
            //    if (tokens.Length > 3)
            //    {
            //        var postIds = tokens[3]
            //            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            //            .Select(int.Parse)
            //            .ToArray();

            //        existingUser = new User(id, username, password, postIds);
            //    }
            //    else
            //    {
            //        existingUser = new User(id, username, password);
            //    }
            //    users.Add(existingUser);
            //}
        }

        return categories;
    }

    public static void SaveCategories(List<Category> categories)
    {
        List<string> lines = new List<string>();

        foreach (var category in categories)
        {
            const string categoryFormat = "{0};{1};{2}";
            string line = string.Format(categoryFormat,
                category.Id,
                category.Name,
                string.Join(",", category.Posts)
                );

            lines.Add(line);
        }

        WriteLines(config["categories"], lines.ToArray());
    }

    private static void EnsureConfigFile(string configPath)
    {
        if (!File.Exists(configPath))
        {
            File.WriteAllText(configPath, DEFAULT_CONFIG);
        }
    }

    private static void EnsureFile(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }
    }

    private static Dictionary<string, string> LoadConfig(string configPath)
    {
        EnsureConfigFile(configPath);

        var contents = ReadLines(configPath);

        var config = contents
                .Select(l => l.Split('='))
                .ToDictionary(t => t[0], t => DATA_PATH + t[1]);

        return config;
    }

    private static string[] ReadLines(string path)
    {
        EnsureFile(path);
        var lines = File.ReadAllLines(path);

        return lines;
    }

    private static void WriteLines(string path, string[] lines)
    {
        File.WriteAllLines(path, lines);
    }
}