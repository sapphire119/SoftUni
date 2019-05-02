using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class RaceTower
{
    private const double BoxTime = 20.0;

    private List<Driver> drivers;
    private string currentWeather;

    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.currentWeather = "Sunny";
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        Track.TotalNumberOfLaps = lapsNumber;
        Track.Length = trackLength;
        Track.CompletedLaps = 0;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driverType = commandArgs[0];
            var driverName = commandArgs[1];
            var carHp = int.Parse(commandArgs[2]);
            var carFuelAmount = double.Parse(commandArgs[3]);
            var tyreType = commandArgs[4];
            var tyreHardness = double.Parse(commandArgs[5]);

            Tyre tyre = null;
            Driver driver = null;

            switch (tyreType)
            {
                case "Hard": tyre = new HardTyre(tyreHardness); break;
                case "Ultrasoft":
                    var grip = double.Parse(commandArgs[6]);
                    tyre = new UltrasoftTyre(tyreHardness, grip);
                    break;
                default:
                    return;
            }

            switch (driverType)
            {
                case "Aggressive": driver = new AggressiveDriver(driverName, new Car(carHp, carFuelAmount, tyre)); break;
                case "Endurance": driver = new EnduranceDriver(driverName, new Car(carHp, carFuelAmount, tyre)); break;
                default:
                    return;
            }

            drivers.Add(driver);
        }
        catch (Exception)
        {
            return;
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driverName = commandArgs[1];

        var currentDriver = this.drivers.Find(d => d.Name == driverName);
        if (currentDriver == null)
        {
            return;
        }

        currentDriver.TotalTime += BoxTime;

        switch (reasonToBox)
        {
            case "ChangeTyres":
                var tyreType = commandArgs[2];
                var tyreHardness = double.Parse(commandArgs[3]);
                var car = currentDriver.Car;
                switch (tyreType)
                {
                    case "Hard":
                        if (currentDriver is AggressiveDriver)
                        {
                            currentDriver = new AggressiveDriver(currentDriver.Name, new Car(car.Hp, car.FuelAmount, new HardTyre(tyreHardness)));
                        }
                        else if (currentDriver is EnduranceDriver)
                        {
                            currentDriver = new EnduranceDriver(currentDriver.Name, new Car(car.Hp, car.FuelAmount, new HardTyre(tyreHardness)));
                        }
                        break;
                    case "Ultrasoft":
                        var grip = double.Parse(commandArgs[4]);
                        if (currentDriver is AggressiveDriver)
                        {
                            currentDriver = new AggressiveDriver(currentDriver.Name, new Car(car.Hp, car.FuelAmount, new UltrasoftTyre(tyreHardness, grip)));
                        }
                        else if (currentDriver is EnduranceDriver)
                        {
                            currentDriver = new EnduranceDriver(currentDriver.Name, new Car(car.Hp, car.FuelAmount, new UltrasoftTyre(tyreHardness, grip)));
                        }
                        break;
                    default:
                        break;
                }
                break;
            case "Refuel":
                var fuelAmount = double.Parse(commandArgs[2]);
                if (fuelAmount > 0.0)
                {
                    currentDriver.Car.Refuel(fuelAmount);
                }
                break;
            default:
                return;
        }

        var currentDrivers = this.drivers.Where(d => !d.IsOutOfRace).OrderBy(d => d.TotalTime).ToList();
        var crashedDrivers = this.drivers.Where(d => d.IsOutOfRace).ToList();

        this.drivers = new List<Driver>(currentDrivers);
        this.drivers.AddRange(crashedDrivers);
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int currrentLapCount = int.Parse(commandArgs[0]);

        if (Track.TotalNumberOfLaps - currrentLapCount < 0)
        {
            return $"There is no time! On lap {Track.CompletedLaps}.";
        }

        var result = CompleteRaceLaps(currrentLapCount);

        Track.CompletedLaps += currrentLapCount;

        return result;
    }

    private string CompleteRaceLaps(int currrentLapCount)
    {
        StringBuilder sb = new StringBuilder();

        var driversWhoAreAlreadyOutOfRace = new Queue<Driver>();

        foreach (var driver in this.drivers)
        {
            if (driver.IsOutOfRace)
                driversWhoAreAlreadyOutOfRace.Enqueue(driver);
        }

        var currentDrivers = new List<Driver>(this.drivers.Where(d => !d.IsOutOfRace));

        var crashedDrivers = new List<Driver>();

        for (int lap = 0; lap < currrentLapCount; lap++)
        {
            foreach (var driver in currentDrivers)
            {
                if (driver.IsOutOfRace)
                    continue;

                double currentTotalTime = (60.0 / (Track.Length / driver.Speed));
                driver.TotalTime += currentTotalTime;

                try
                {
                    driver.Car.FuelAmount -= (Track.Length * driver.FuelConsumptionPerKm);
                    driver.Car.Tyre.DegradateTyre();
                }
                catch (ArgumentException ae)
                {
                    driver.FailureReason = ae.Message;
                    driver.IsOutOfRace = true;
                    crashedDrivers.Add(driver);
                }

            }
            currentDrivers = currentDrivers.OrderBy(d => d.TotalTime).ToList();

            sb.AppendLine(CheckForOvertakingOportunities(lap));
        }

        var leftDrivers = currentDrivers.Where(d => !d.IsOutOfRace).OrderBy(d => d.TotalTime).ToList();
        this.drivers = new List<Driver>(leftDrivers);
        this.drivers.AddRange(crashedDrivers);
        foreach (var alreadyCrashedDriver in driversWhoAreAlreadyOutOfRace)
        {
            this.drivers.Add(alreadyCrashedDriver);
        }

        var result = sb.ToString().TrimEnd();
        return result;
    }

    private string CheckForOvertakingOportunities(int currentLapCount)
    {
        StringBuilder sb = new StringBuilder();

        var driversWhoAreAlreadyOutOfRace = new Queue<Driver>();

        foreach (var driver in this.drivers)
        {
            if (driver.IsOutOfRace)
                driversWhoAreAlreadyOutOfRace.Enqueue(driver);
        }

        var currentDrivers = new List<Driver>(this.drivers.Where(d => !d.IsOutOfRace).OrderBy(d => d.TotalTime));
        var copyDrivers = new List<Driver>(currentDrivers);

        var crashedDrivers = new List<Driver>();

        for (int position = currentDrivers.Count - 1; position >= 1; position--)
        {
            var currentDriver = currentDrivers[position];

            if (currentDriver.IsOutOfRace)
                continue;

            var overtakeInterval = 2;

            bool aggresiveDriverCondition = currentDriver.GetType().Name == nameof(AggressiveDriver) && currentDriver.Car.Tyre.Name == "Ultrasoft";
            bool enduranceDriverCondtion = currentDriver.GetType().Name == nameof(EnduranceDriver) && currentDriver.Car.Tyre.Name == "Hard";

            bool crashCondition =
                aggresiveDriverCondition && this.currentWeather == "Foggy" ||
                enduranceDriverCondtion && this.currentWeather == "Rainy";

            if (aggresiveDriverCondition || enduranceDriverCondtion)
            {
                if (crashCondition)
                {
                    currentDriver.IsOutOfRace = true;
                    currentDriver.FailureReason = "Crashed";
                    crashedDrivers.Add(currentDriver);
                    continue;
                }

                overtakeInterval = 3;
            }

            var driverAhead = currentDrivers[position - 1];
            if (currentDriver.TotalTime - driverAhead.TotalTime <= overtakeInterval)
            {
                currentDriver.TotalTime -= overtakeInterval;
                copyDrivers[position - 1] = currentDriver;
                driverAhead.TotalTime += overtakeInterval;
                copyDrivers[position] = driverAhead;
                position--;
                sb.AppendLine($"{currentDriver.Name} has overtaken {driverAhead.Name} on lap {currentLapCount}.");
            }
        }

        var leftDrivers = copyDrivers.Where(d => !d.IsOutOfRace).OrderBy(d => d.TotalTime).ToList();
        this.drivers = new List<Driver>(leftDrivers);
        this.drivers.AddRange(crashedDrivers);
        foreach (var alreadyCrashedDriver in driversWhoAreAlreadyOutOfRace)
        {
            this.drivers.Add(alreadyCrashedDriver);
        }

        var result = sb.ToString().TrimEnd();

        return result;
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Lap {Track.CompletedLaps}/{Track.TotalNumberOfLaps}");

        for (int position = 0; position < this.drivers.Count; position++)
        {
            var currentDriver = this.drivers[position];

            var printCondition = currentDriver.IsOutOfRace == true ? currentDriver.FailureReason : $"{currentDriver.TotalTime:f3}";
            sb.AppendLine($"{position + 1} {currentDriver.Name} {printCondition}");
        }

        var result = sb.ToString().TrimEnd();

        return result;

    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var weather = commandArgs[0];
        this.currentWeather = weather;
    }

    public Driver GetWinner()
    {
        return this.drivers.FirstOrDefault();
    }
}