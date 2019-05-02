namespace BusTicket.Models
{
    using System.Collections.Generic;

    public class BusStation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Trip> OriginBusStationTrips { get; set; } = new List<Trip>();

        public ICollection<Trip> DestinationBusStationTrips { get; set; } = new List<Trip>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
