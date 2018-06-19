using System.Linq;
using System.Collections.Generic;
using Forum.App.UserInterface.ViewModels;

public static class PostService
{
    internal static IList<ReplyViewModel> GetPostReplies(int postId)
    {
        ForumData forumData = new ForumData();

        Post post = forumData.Posts.Find(p => p.Id == postId);

        IList<ReplyViewModel> replies = new List<ReplyViewModel>();

        foreach (var replyId in post.Replies)
        {
            var reply = forumData.Replies.Find(r => r.Id == replyId);
            replies.Add(new ReplyViewModel(reply));
        }

        return replies;
    }

    internal static Category GetCategory(int categoryId)
    {
        ForumData forumData = new ForumData();

        Category category = forumData.Cateogires.Find(c => c.Id == categoryId);

        return category;
    }

    internal static Category GetCategory(string name)
    {
        ForumData forumData = new ForumData();

        Category category = forumData.Cateogires.Find(c => c.Name == name);

        return category;
    }

    internal static string[] GetAllCategoryNames()
    {
        ForumData forumData = new ForumData();

        var allCategories = forumData.Cateogires.Select(c => c.Name).ToArray();

        return allCategories;
    }

    internal static IEnumerable<Post> GetPostsByCategory(int categoryId)
    {
        ForumData forumData = new ForumData();

        var postIds = forumData.Cateogires.FirstOrDefault(c => c.Id == categoryId).Posts;

        IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

        return posts;
    }

    public static PostViewModel GetPostViewModel(int postId)
    {
        ForumData forumData = new ForumData();

        Post post = forumData.Posts.Find(p => p.Id == postId);

        PostViewModel postViewModel = new PostViewModel(post);

        return postViewModel;
    }

    private static Category EnsureCategory(PostViewModel postViewModel, ForumData forumData)
    {
        var categoryName = postViewModel.Category;
        Category category = forumData.Cateogires.FirstOrDefault(x => x.Name == categoryName);
        if (category == null)
        {
            var categories = forumData.Cateogires;
            int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
            category = new Category(categoryId, categoryName, new List<int>());
            forumData.Cateogires.Add(category);
        }

        return category;
    }

    public static bool TrySavePost(PostViewModel postView)
    {
        bool emptyCategroy = string.IsNullOrWhiteSpace(postView.Category);
        bool emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
        bool emptyContent = !postView.Content.Any();

        if (emptyCategroy || emptyTitle || emptyContent)
        {
            return false;
        }

        ForumData forumData = new ForumData();

        Category category = EnsureCategory(postView, forumData);

        int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;
        User author = UserService.GetUser(postView.Author);

        int authorId = author.Id;
        string content = string.Join("", postView.Content);

        Post post = new Post(postId, postView.Title, content, category.Id, authorId, new List<int>());

        forumData.Posts.Add(post);
        author.Posts.Add(post.Id);
        category.Posts.Add(post.Id);
        forumData.SaveChanges();

        postView.PostId = postId;

        return true;
    }
}