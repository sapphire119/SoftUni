using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Index.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
            : base() { }

        public AppUser(string username)
            : base(username) { }

        public ICollection<Message> Messages { get; set; }
    }
}
