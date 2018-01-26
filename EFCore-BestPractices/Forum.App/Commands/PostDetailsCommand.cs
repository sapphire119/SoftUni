namespace Forum.App.Commands
{
    using System.Linq;
    using System.Text;

    using Forum.App.Commands.Contrancts;
    using Forum.Services.Contracts;
    using Forum.App.ModelsDto;

    using AutoMapper;

    public class PostDetailsCommand : ICommand
    {
        private readonly IPostService postService;

        public PostDetailsCommand(IPostService postService)
        {
            this.postService = postService;
        }

        public string Execute(params string[] arguments)
        {
            var postId = int.Parse(arguments[0]);

            var post = postService.ById<PostDetailsDto>(postId);

            var postDto = Mapper.Map<PostDetailsDto>(post);
            //var postDto = new PostDetailsDto
            //{
            //    Id = post.Id,
            //    Title = post.Title,
            //    Content = post.Content,
            //    AuthorUsername = post.Author.Username,
            //    Replies = post.Replies.Select(r => new ReplyDto
            //    {
            //        Content = r.Content,
            //        AuthorUsername = r.Author.Username
            //    })
            //    .ToArray()
            //};

            var sb = new StringBuilder();
             
            sb.AppendLine($"{postDto.Title} by {postDto.AuthorUsername}");

            foreach (var reply in postDto.Replies)
            {
                sb.AppendLine($"---- {reply.Content} by {reply.AuthorUsername}");
            }

            return sb.ToString();

        }
    }
}
