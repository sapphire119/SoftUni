namespace Forum.App.Commands
{
    using Forum.Models;
    using Forum.Services.Contracts;
    using Forum.App.Commands.Contrancts;

    public class CreatePostCommand : ICommand
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public CreatePostCommand(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }

        public string Execute(params string[] arguments)
        {
            var categoryName = arguments[0];
            var postTitle = arguments[1];
            var postContent = arguments[2];

            var category = categoryService.ByName<Category>(categoryName);

            if (Session.User == null)
            {
                return "You are not logged in!";
            }

            if (category == null)
            {
                category = categoryService.Create<Category>(categoryName);
            }

            var authorId = Session.User.Id;
            var categoryId = category.Id;

            var post = postService.Create(postTitle, postContent, categoryId, authorId);

            return $"Post with Id {post.Id} created succesfully!";
        }
    }
}
