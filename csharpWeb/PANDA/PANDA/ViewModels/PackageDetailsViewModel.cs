using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.ViewModels
{
    public class PackageDetailsViewModel
    {
        public string Address { get; set; }

        public string Status { get; set; }

        [Display(Name = "Estimated Time of Delivery")]
        public string ETA { get; set; }

        public decimal Weight { get; set; }

        public string Recipient { get; set; }

        public string Description { get; set; }

    }
}
