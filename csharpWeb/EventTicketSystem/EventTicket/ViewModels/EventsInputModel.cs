using EventTicket.Helpers;
using EventTicket.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.ViewModels
{
    public class EventsInputModel
    {
        [Required]
        [StringLength(10,MinimumLength = 10, ErrorMessage = GlobalConstants.EventNameLengthError)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Place { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DateValidation(ErrorMessage = GlobalConstants.DateParseErrorMessage)]
        public DateTime? Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DateValidation(ErrorMessage = GlobalConstants.DateParseErrorMessage)]
        public DateTime? End { get; set; }

        [Display(Name = "Total Tickets")]
        [Range(1, int.MaxValue, ErrorMessage = GlobalConstants.TicketsBelowMinValueErrorMessage)]
        public int TotalTickets { get; set; }

        [Display(Name = "Price Per Ticket")]
        [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = GlobalConstants.TicketMinPriceErrorMessage)]
        
        public decimal PricePerTicket { get; set; }
    }
}
