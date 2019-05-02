using System.Linq;
using System.Collections.Generic;
using Forum.App.UserInterface.ViewModels;

public class ReplyService
{


    ////private static Category EnsureCategory(PostViewModel postViewModel, ForumData forumData)
    ////{
    ////    var categoryName = postViewModel.Category;
    ////    Category category = forumData.Cateogires.FirstOrDefault(x => x.Name == categoryName);
    ////    if (category == null)
    ////    {
    ////        var categories = forumData.Cateogires;
    ////        int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
    ////        category = new Category(categoryId, categoryName, new List<int>());
    ////        forumData.Cateogires.Add(category);
    ////    }

    ////    return category;
    ////}

    //public static bool TryAddReply(ReplyViewModel replyView)
    //{
    //    bool emptyAuthor = string.IsNullOrWhiteSpace(replyView.Author);
    //    bool emptyContent = !replyView.Content.Any();

    //    if (emptyAuthor || emptyContent)
    //    {
    //        return false;
    //    }

    //    ForumData forumData = new ForumData();

    //    Category category = EnsureCategory(postView, forumData);

    //    int replyId = forumData.Replies.Any() ? forumData.Replies.Last().Id + 1 : 1;

    //    User author = UserService.GetUser(replyView.Author);

    //    int authorId = author.Id;
    //    string content = string.Join("", replyView.Content);

    //    Reply reply = new Reply(replyId, content, authorId, );

    //    forumData.Posts.Add(reply);
    //    author.Posts.Add(reply.Id);
    //    category.Posts.Add(reply.Id);
    //    forumData.SaveChanges();

    //    postView.PostId = replyId;

    //    return true;
    //}
}