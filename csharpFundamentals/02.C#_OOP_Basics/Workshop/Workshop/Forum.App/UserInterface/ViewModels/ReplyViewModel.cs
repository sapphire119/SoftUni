namespace Forum.App.UserInterface.ViewModels
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ReplyViewModel
    {
        private const int LINE_LENGHT = 37;

        public ReplyViewModel() { }

        public ReplyViewModel(Reply reply)
            : this()
        {
            this.Author = UserService.GetUser(reply.AuthorId).Username;
            this.Content = GetLines(reply.Content);
        }

        public string Author { get; set; }

        public IList<string> Content { get; set; } = new List<string>();

        private IList<string> GetLines(string content) 
        {
            var contentOfChars = content.ToCharArray();

            IList<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i += LINE_LENGHT)
            {
                char[] row = contentOfChars.Skip(1).Take(LINE_LENGHT).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines;
        }
    }
}