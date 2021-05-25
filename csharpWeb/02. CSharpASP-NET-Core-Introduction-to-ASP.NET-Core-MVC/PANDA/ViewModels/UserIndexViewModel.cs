using Panda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.ViewModels
{
    public class UserIndexViewModel
    {
        public UserIndexViewModel(
            IEnumerable<Package> pendingPackages,
            IEnumerable<Package> shippedPackages,
            IEnumerable<Package> deliveredPackages)
        {
            PendingPackages = pendingPackages;
            ShippedPackages = shippedPackages;
            DeliveredPackages = deliveredPackages;
        }

        public IEnumerable<Package> PendingPackages { get; set; }
        public IEnumerable<Package> ShippedPackages { get; set; }
        public IEnumerable<Package> DeliveredPackages { get; set; }
    }
}
