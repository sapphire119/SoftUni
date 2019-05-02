namespace Forum.Services
{
    using System.Linq;
    using Forum.Data;
    using Forum.Models;
    using Forum.Services.Contracts;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;

    public class ReplyService : IReplyService
    {
        private readonly ForumDbContext context;

        public ReplyService(ForumDbContext context)
        {
            this.context = context;
        }

        public TModel Create<TModel>(string replyText, int postId, int authorId)
        {
            var reply = new Reply()
            {
                Content = replyText,
                PostId = postId,
                AuthorId = authorId
            };

            context.Replies.Add(reply);

            context.SaveChanges();

            var dto = Mapper.Map<TModel>(reply);

            return dto;
        }

        public void Delete(int replyId)
        {
            throw new System.NotImplementedException();
        }
    }
}
