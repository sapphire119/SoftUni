﻿using System.Collections.Generic;

public class Post
{
    public Post(int id, string title, string content, int categoryId, int authorId)
    {
        this.Id = id;
        this.Title = title;
        this.Content = content;
        this.CategoryId = categoryId;
        this.AuthorId = authorId;
    }

    public Post(int id, string title, string content, int categoryId, int authorId, IEnumerable<int> replies)
        : this(id, title, content, categoryId, authorId)
    {
        this.Replies = new List<int>(replies);
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public int CategoryId { get; set; }

    public int AuthorId { get; set; }

    public IEnumerable<int> Replies { get; set; } = new List<int>();
}