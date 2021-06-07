using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.ViewModels
{
    public class EventsInputModel
    {
        public string Name { get; set; }

        public string Place { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        [Display(Name = "Total Tickets")]
        public int TotalTickets { get; set; }

        [Display(Name = "Price Per Ticket")]
        public decimal PricePerTicket { get; set; }
    }
}
