using System;

namespace BusTicket.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public GradeType Grade { get; set; }

        public int BusStationId { get; set; }
        public BusStation BusStation { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime? DateAndTimeOfPublishing { get; set; }
    }
}
