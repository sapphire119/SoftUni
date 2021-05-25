namespace Panda.ViewModels
{
    using System;

    public class PackageViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string Recipient { get; set; }

        public DateTime? DeliveryDate { get; set; }
    }
}
