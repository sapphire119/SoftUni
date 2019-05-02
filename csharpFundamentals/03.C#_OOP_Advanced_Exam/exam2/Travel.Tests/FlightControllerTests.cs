// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Travel.Core.Controllers;
    using Travel.Core.Controllers.Contracts;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Contracts;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
        private IFlightController flightController;
        private IAirport airport;
        private ITrip trip;

        [SetUp]
        public void Initilialize()
        {
            this.airport = new Airport();
            this.flightController = new FlightController(airport);
            this.trip = SetUpTrip();
        }

        private ITrip SetUpTrip()
        {
            var type = typeof(Trip);

            var instance = Activator.CreateInstance(type, new object[] { "Sofia", "London", new LightAirplane() });

            var field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Static).SingleOrDefault(t => t.FieldType == typeof(int));

            field.SetValue(instance, 1);

            return (ITrip)instance;
        }

        [Test]  
        public void TripShouldBeComplete()
        {
            var expected = true;

            IPassenger passanger = new Passenger("Pesho");
            IPassenger passanger1 = new Passenger("Ivan");
            IPassenger passanger2 = new Passenger("Gosho");
            IPassenger passanger3 = new Passenger("Stamat");

            var bag = new Bag(passanger, new Item[] { new Laptop(), new Jewelery(), new Colombian() });

            passanger.Bags.Add(bag);

            this.trip.Airplane.AddPassenger(passanger);
            this.trip.Airplane.AddPassenger(passanger1);
            this.trip.Airplane.AddPassenger(passanger2);
            this.trip.Airplane.AddPassenger(passanger3);

            this.airport.AddTrip(this.trip);

            this.flightController.TakeOff();

            var type = typeof(FlightController);

            var field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).SingleOrDefault(f => f.FieldType == typeof(IAirport));

            var airportValue = (IAirport)field.GetValue(this.flightController);

            Assert.That(airport.Trips.First().IsCompleted, Is.EqualTo(expected));
        }

        [Test]
        public void LoadingOfBagsOntoPlane()
        {
            var expected = 1;

            IPassenger passanger = new Passenger("Pesho");
            IPassenger passanger1 = new Passenger("Ivan");
            IPassenger passanger2 = new Passenger("Gosho");
            IPassenger passanger3 = new Passenger("Stamat");

            var bag = new Bag(passanger, new Item[] { new Laptop(), new Jewelery(), new Colombian() });

            passanger.Bags.Add(bag);

            this.trip.Airplane.AddPassenger(passanger);
            this.trip.Airplane.AddPassenger(passanger1);
            this.trip.Airplane.AddPassenger(passanger2);
            this.trip.Airplane.AddPassenger(passanger3);

            this.airport.AddTrip(this.trip);

            this.flightController.TakeOff();
            
            var type = typeof(FlightController);

            var field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).SingleOrDefault(f => f.FieldType == typeof(IAirport));

            var airportValue = (IAirport)field.GetValue(this.flightController);

            Assert.That(airportValue.Trips.First().Airplane.BaggageCompartment.Count, Is.EqualTo(expected));
        }

        [Test]
        public void PlaneOverBooked()
        {
            IPassenger passanger = new Passenger("Pesho");
            IPassenger passanger1 = new Passenger("Ivan");
            IPassenger passanger2 = new Passenger("Gosho");
            IPassenger passanger3 = new Passenger("Stamat");
            IPassenger passanger4 = new Passenger("Penka");
            IPassenger passanger5 = new Passenger("Pesho1");
            IPassenger passanger6 = new Passenger("Ivan2");
            IPassenger passanger7 = new Passenger("Gosho3");
            IPassenger passanger8 = new Passenger("Stamat4");


            this.trip.Airplane.AddPassenger(passanger);
            this.trip.Airplane.AddPassenger(passanger1);
            this.trip.Airplane.AddPassenger(passanger2);
            this.trip.Airplane.AddPassenger(passanger3);
            this.trip.Airplane.AddPassenger(passanger4);
            this.trip.Airplane.AddPassenger(passanger5);
            this.trip.Airplane.AddPassenger(passanger6);
            this.trip.Airplane.AddPassenger(passanger7);
            this.trip.Airplane.AddPassenger(passanger8);

            this.airport.AddTrip(trip);

            var result = this.flightController.TakeOff();

            var expected = 5;

            var type = typeof(FlightController);

            var field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).SingleOrDefault(f => f.FieldType == typeof(IAirport));

            var airportValue = (IAirport)field.GetValue(this.flightController);

            Assert.That(airportValue.Trips.First().Airplane.Passengers.Count, Is.EqualTo(expected));
        }

        [Test]
        public void EjectedBags_RightCount()
        {
            var expected = 1;
            
            IPassenger passanger = new Passenger("Pesho");
            IPassenger passanger1 = new Passenger("Ivan");
            IPassenger passanger2 = new Passenger("Gosho");
            IPassenger passanger3 = new Passenger("Stamat");
            IPassenger passanger4 = new Passenger("Penka");
            IPassenger passanger5 = new Passenger("Pesho1");
            IPassenger passanger6 = new Passenger("Ivan2");
            IPassenger passanger7 = new Passenger("Gosho3");
            IPassenger passanger8 = new Passenger("Stamat4");

            var bag = new Bag(passanger, new Item[] { new Laptop(), new Jewelery() });

            passanger.Bags.Add(bag);

            this.trip.Airplane.AddPassenger(passanger);
            this.trip.Airplane.AddPassenger(passanger1);
            this.trip.Airplane.AddPassenger(passanger2);
            this.trip.Airplane.AddPassenger(passanger3);
            this.trip.Airplane.AddPassenger(passanger4);
            this.trip.Airplane.AddPassenger(passanger5);
            this.trip.Airplane.AddPassenger(passanger6);
            this.trip.Airplane.AddPassenger(passanger7);
            this.trip.Airplane.AddPassenger(passanger8);

            this.airport.AddTrip(trip);

            var result = this.flightController.TakeOff();

            var type = typeof(FlightController);

            var field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).SingleOrDefault(f => f.FieldType == typeof(IAirport));

            var airportValue = (IAirport)field.GetValue(this.flightController);

            Assert.That(airportValue.ConfiscatedBags.Count, Is.EqualTo(expected));
        }

        [Test]
        public void EjectedPassangers_StringResult()
        {
            IPassenger passanger = new Passenger("Pesho");
            IPassenger passanger1 = new Passenger("Ivan");
            IPassenger passanger2 = new Passenger("Gosho");
            IPassenger passanger3 = new Passenger("Stamat");
            IPassenger passanger4 = new Passenger("Penka");
            IPassenger passanger5 = new Passenger("Pesho1");
            IPassenger passanger6 = new Passenger("Ivan2");
            IPassenger passanger7 = new Passenger("Gosho3");
            IPassenger passanger8 = new Passenger("Stamat4");

            this.trip.Airplane.AddPassenger(passanger);
            this.trip.Airplane.AddPassenger(passanger1);
            this.trip.Airplane.AddPassenger(passanger2);
            this.trip.Airplane.AddPassenger(passanger3);
            this.trip.Airplane.AddPassenger(passanger4);
            this.trip.Airplane.AddPassenger(passanger5);
            this.trip.Airplane.AddPassenger(passanger6);
            this.trip.Airplane.AddPassenger(passanger7);
            this.trip.Airplane.AddPassenger(passanger8);

            this.airport.AddTrip(trip);

            var result = this.flightController.TakeOff();

            var expected = "SofiaLondon1:" + Environment.NewLine +
                            "Overbooked! Ejected Ivan, Pesho, Stamat, Gosho3" + Environment.NewLine +
                            "Confiscated 0 bags ($0)" + Environment.NewLine +
                            "Successfully transported 5 passengers from Sofia to London." + Environment.NewLine +
                            "Confiscated bags: 0 (0 items) => $0";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TripShouldBeSkippedIfCompleted()
        {
            this.trip.Complete();

            this.airport.AddTrip(this.trip);

            var result = this.flightController.TakeOff();

            var expected = "Confiscated bags: 0 (0 items) => $0";

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
