namespace Travel.Entities.Airplanes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Contracts;

    public abstract class Airplane : IAirplane
    {
        private List<IBag> bags;
        private List<IPassenger> passengers;
        
        public Airplane(int seats, int baggageCompartment)
        {
            this.bags = new List<IBag>();
            this.passengers = new List<IPassenger>();

            this.Seats = seats;
            this.BaggageCompartments = baggageCompartment;
        }

        public int Seats { get; }

        public int BaggageCompartments { get; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.bags.AsReadOnly();

        public bool IsOverbooked => this.passengers.Count > this.Seats;

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();


        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seat)
        {
            var passenger = this.passengers.ElementAtOrDefault(seat);
            if (passengers == null)
            {
                return default(IPassenger);
            }

            this.passengers.RemoveAt(seat);

            return passenger;
        }

        public void LoadBag(IBag bag)
        {
            var isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;
            if (isBaggageCompartmentFull)
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");

            this.bags.Add(bag);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var passengerBags = this.bags
                .Where(b => b.Owner == passenger)
                .ToArray();

            foreach (var bag in passengerBags)
                this.bags.Remove(bag);

            return passengerBags;
        }
    }
}
