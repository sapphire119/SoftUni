﻿namespace Forum.App.Commands
{
    using Forum.Services.Contracts;
    using Forum.App.Commands.Contrancts;
    using Forum.Models;

    public class ReplyCommand : ICommand
    {
        private readonly IReplyService replyService;

        public ReplyCommand(IReplyService replyService)
        {
            this.replyService = replyService;
        }

        public string Execute(params string[] arguments)
        {
            var postId = int.Parse(arguments[0]);
            var content = arguments[1];

            if (Session.User == null)
            {
                return "You are not logged in!";
            }

            var authorId = Session.User.Id;

            replyService.Create<Reply>(content, postId, authorId);

            return "Reply created successfully!";
        }
    }
}
