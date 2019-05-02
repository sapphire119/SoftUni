namespace BusTicket.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public ICollection<BusStation> BusStations { get; set; } = new List<BusStation>();

        public ICollection<Customer> NativePeople { get; set; } = new List<Customer>();

    }
}
