﻿public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car)
        : base(name, 0, car, 2.7)
    {
    }

    public override double Speed => base.Speed * 1.3;
}