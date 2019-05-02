using Forum.Models;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Services.Contracts
{
    public interface IPostService
    {
        TModel ById<TModel>(int postId);

        Post Create(string title, string content, int categoryId, int authorId);

        IQueryable<TModel> All<TModel>();
    }
}
    