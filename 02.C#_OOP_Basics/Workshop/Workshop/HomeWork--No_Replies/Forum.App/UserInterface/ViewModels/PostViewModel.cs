namespace Forum.App.UserInterface.ViewModels
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PostViewModel
    {
        private const int LINE_LENGHT = 37;

        public PostViewModel() { }

        public PostViewModel(Post post)
            : this()
        {
            this.PostId = post.Id;
            this.Title = post.Title;
            this.Content = this.GetLines(post.Content);
            this.Author = UserService.GetUser(post.AuthorId).Username;
            this.Category = PostService.GetCategory(post.CategoryId).Name;
            this.Replies = PostService.GetPostReplies(post.Id);
        }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public IList<string> Content { get; set; } = new List<string>();

        public IList<ReplyViewModel> Replies { get; set; } = new List<ReplyViewModel>();

        private IList<string> GetLines(string content)
        {
            var contentOfChars = content.ToCharArray();

            IList<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i+= LINE_LENGHT)
            {
                char[] row = contentOfChars.Skip(1).Take(LINE_LENGHT).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines;
        }
    }
}
