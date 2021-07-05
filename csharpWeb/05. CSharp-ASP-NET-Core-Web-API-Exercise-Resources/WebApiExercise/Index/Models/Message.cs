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

        public Message(string content, string user)
            : this(Guid.NewGuid())
        {
            this.Content = content;
            this.User = user;
        }

        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string User { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
