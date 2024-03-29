﻿using System.Collections.Generic;

public class ForumData
{
    public ForumData()
    {
        this.Users = DataMapper.LoadUsers();
        this.Cateogires = DataMapper.LoadCategories();
        this.Posts = DataMapper.LoadPosts();
        this.Replies = DataMapper.LoadReplies();
    }

    public List<Category> Cateogires { get; set; }

    public List<User> Users { get; set; }

    public List<Post> Posts { get; set; }

    public List<Reply> Replies { get; set; }

    public void SaveChanges()
    {
        DataMapper.SaveUsers(this.Users);
        DataMapper.SaveCategories(this.Cateogires);
        DataMapper.SavePosts(this.Posts);
        DataMapper.SaveReplies(this.Replies);
    }
}