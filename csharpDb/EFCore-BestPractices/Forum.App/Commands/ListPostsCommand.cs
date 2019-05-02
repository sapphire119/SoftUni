namespace Forum.App.Commands
{
    using System;
    using System.Linq;
    using System.Text;

    using Forum.Services.Contracts;
    using Forum.App.Commands.Contrancts;
    using Forum.App.ModelsDto;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class ListPostsCommand : ICommand
    {
        private readonly IPostService postService;

        public ListPostsCommand(IPostService postService)
        {
            this.postService = postService;
        }

        public string Execute(params string[] arguments)
        {
            //Чрез DTO-та се строго типизират заявките
            var posts = postService
                    .All<PostDto>()//<PostDto/*PostDetailsDto*/>() //Ползваме ProjectTo<> като преди това сме дефинирали .All() като IQuerryable, ако не ползваме Generi-ци
                    .GroupBy(p => p.CategoryName)
                    .ToArray();

            var sb = new StringBuilder();

            foreach (var group in posts)
            {
                var categoryName = group.Key;

                sb.AppendLine(categoryName + ":");

                foreach (var post in group)
                {
                    sb.AppendLine(
                        $"--{post.Id}. {post.Title} - {post.Content} by {post.AuthorUsername}");
                }

            }

            return sb.ToString();
        }
    }
}
