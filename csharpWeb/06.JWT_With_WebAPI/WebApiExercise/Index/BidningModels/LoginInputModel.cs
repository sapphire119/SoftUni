using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Index.BidningModels
{
    public class LoginInputModel
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
