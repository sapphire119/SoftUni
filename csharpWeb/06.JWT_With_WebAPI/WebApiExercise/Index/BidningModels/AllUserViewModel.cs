﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Index.BidningModels
{
    public class AllUserViewModel
    {
        public AllUserViewModel(string username, string content)
        {
            this.Username = username;
            this.Content = content;
        }

        public string Username { get; set; }

        public string Content { get; set; }
    }
}
