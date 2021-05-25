using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.ViewModels
{
    public class ReceiptIndexViewModel
    {
        public ReceiptIndexViewModel(int id, decimal weight, string issuedOn, string recepient)
        {
            Id = id;
            Weight = weight;
            IssuedOn = issuedOn;
            Recepient = recepient;
        }

        public int Id { get; set; }

        public decimal Weight { get; set; }


        public string IssuedOn { get; set; }

        public string Recepient { get; set; }

        public decimal Fee => Math.Round(this.Weight * 2.67M, 2);

    }
}
