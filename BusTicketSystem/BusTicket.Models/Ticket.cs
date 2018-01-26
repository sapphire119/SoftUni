namespace BusTicket.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Seat { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
