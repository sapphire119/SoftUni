﻿namespace Forum.App.ModelsDto
{
    using System.Collections.Generic;

    public class PostDetailsDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorUsername { get; set; }

        public int ReplyCount { get; set; }

        public IEnumerable<ReplyDto> Replies { get; set; }

    }
}
