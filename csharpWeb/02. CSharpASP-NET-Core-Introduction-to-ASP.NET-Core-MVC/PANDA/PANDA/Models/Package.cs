namespace Panda.Models
{
    using Panda.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;


    public class Package
    {
        public Package() { }

        public Package(string description, decimal weight, string shippingAddress, int recepientId)
            : this()
        {
            Description = description;
            Weight = weight;
            ShippingAddress = shippingAddress;
            RecipientId = recepientId;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        [Display(Name = "Estimated Delivery Date")]
        public DateTime? ETA { get; set; }


        public int RecipientId { get; set; }

        public User Recipient { get; set; }


        public int ReceiptId { get; set; }

        public Receipt Receipt { get; set; }
    }
}
