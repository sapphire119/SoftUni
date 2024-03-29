﻿
namespace Forum.Services
{
    using System.Linq;

    using Forum.Data;
    using Forum.Models;
    using Forum.Services.Contracts;

    using Microsoft.EntityFrameworkCore;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;

    public class PostService : IPostService
    {
        private readonly ForumDbContext context;

        public PostService(ForumDbContext context)
        {
            this.context = context;
        }

        public TModel ById<TModel>(int postId)
        {
            var post = context.Posts
                    .Where(p => p.Id == postId)
                    .ProjectTo<TModel>()
                    .SingleOrDefault();

            return post;
        }

        public Post Create(string title, string content, int categoryId, int authorId)
        {
            var post = new Post()
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                AuthorId = authorId
            };

            context.Posts.Add(post);

            context.SaveChanges();

            return post;
        }

        public IQueryable<TModel> All<TModel>()
        {
            var posts = context.Posts
                    .ProjectTo<TModel>();

            return posts;
        }
    }
}
