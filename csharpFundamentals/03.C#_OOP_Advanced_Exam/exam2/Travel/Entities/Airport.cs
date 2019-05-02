namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;

    public class Airport : IAirport
    {
        private List<IBag> checkedInBags;
        private List<IBag> confiscatedBags;
        private List<ITrip> trips;
        private List<IPassenger> passengers;

        public Airport()
        {
            this.checkedInBags = new List<IBag>();
            this.confiscatedBags = new List<IBag>(); 
            this.trips = new List<ITrip>();
            this.passengers = new List<IPassenger>();
        }

        public IReadOnlyCollection<IBag> CheckedInBags => this.checkedInBags.AsReadOnly();

        public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBags.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public IReadOnlyCollection<ITrip> Trips => this.trips.AsReadOnly();

        public void AddCheckedBag(IBag bag)
        {
            this.checkedInBags.Add(bag);
        }

        public void AddConfiscatedBag(IBag bag)
        {
            this.confiscatedBags.Add(bag);
        }

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public void AddTrip(ITrip trip)
        {
            this.trips.Add(trip);
        }

        public IPassenger GetPassenger(string username)
        {
            var existingPassenger = this.passengers.Find(p => p.Username == username);
            if (existingPassenger == null)
            {
                return default(IPassenger);
            }

            return existingPassenger;
        }

        public ITrip GetTrip(string id)
        {
            var existingTrip = this.trips.Find(t => t.Id == id);
            if (existingTrip == null)
            {
                return default(ITrip);
            }

            return existingTrip;
        }
    }
}