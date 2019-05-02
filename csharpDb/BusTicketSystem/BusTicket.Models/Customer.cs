namespace BusTicket.Models
{
    using System;
    using System.Collections.Generic;

    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        //Convert To CHAR(1)
        public string Gender { get; set; }

        public int? HomeTownId { get; set; }
        public Town HomeTown { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    }
}
