namespace Panda.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Receipt
    {
        public Receipt() { }
        public Receipt(decimal fee, DateTime issuedOn, int recipientId, int packageId)
            : this()
        {
           this.Fee = fee;
           this.IssuedOn = issuedOn;
           this.RecipientId = recipientId;
           this.PackageId = packageId;
        }

        public int Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }


        public int RecipientId { get; set; }

        public User Recipient { get; set; }


        public int PackageId { get; set; }

        public Package Package { get; set; }
    }
}
