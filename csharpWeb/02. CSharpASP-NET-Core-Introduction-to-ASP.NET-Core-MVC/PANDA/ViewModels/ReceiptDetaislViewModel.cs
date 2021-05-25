using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.ViewModels
{
    public class ReceiptDetaislViewModel
    {
        public ReceiptDetaislViewModel(int id, string issuedOn, string deliveryAdress, decimal packageWeight, string packageDescription, string recepient)
        {
            Id = id;
            IssuedOn = issuedOn;
            DeliveryAdress = deliveryAdress;
            PackageWeight = packageWeight;
            PackageDescription = packageDescription;
            Recepient = recepient;
        }

        public int Id { get; set; }

        public string IssuedOn { get; set; }

        public string DeliveryAdress { get; set; }

        public decimal PackageWeight { get; set; }

        public string PackageDescription { get; set; }

        public string Recepient { get; set; }

        public decimal Total => Math.Round(this.PackageWeight * 2.67M, 2);
    }
}
