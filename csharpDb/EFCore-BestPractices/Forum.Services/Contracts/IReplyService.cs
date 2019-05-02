namespace Forum.Services.Contracts
{
    using Forum.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IReplyService
    {
        TModel Create<TModel>(string replyText,int postId, int authorId);

        void Delete(int replyId);
    }
}
