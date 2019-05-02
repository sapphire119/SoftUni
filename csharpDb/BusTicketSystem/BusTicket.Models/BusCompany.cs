namespace BusTicket.Models
{
    using System.Collections.Generic;

    public class BusCompany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public RatingType Rating { get; set; }

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}