using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.ViewModels
{
    public class PackageCreateViewModel
    {
        public PackageCreateViewModel()
        {
            this.AllUsers = new List<SelectListItem>();
        }

        public string Description { get; set; }

        public decimal? Weight { get; set; }

        public string ShippingAddress { get; set; }

        public int RecipientId { get; set; }

        public List<SelectListItem> AllUsers { get; set; }
    }
}
