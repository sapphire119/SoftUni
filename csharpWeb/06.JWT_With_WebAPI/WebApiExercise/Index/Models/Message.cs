using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Index.Models
{
    public class Message
    {
        private Message(Guid id)
        {
            this.Id = id;
        }

        public Message(string content, string userId)
            : this(Guid.NewGuid())
        {
            this.Content = content;
            this.UserId = userId;
        }

        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }


        [Required(AllowEmptyStrings = false)]
        public string UserId { get; set; }

        public AppUser User { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
