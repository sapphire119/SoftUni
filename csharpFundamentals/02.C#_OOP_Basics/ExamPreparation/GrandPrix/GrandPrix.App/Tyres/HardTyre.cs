using System;

public class HardTyre : Tyre
{
    public HardTyre(double hardness) 
        : base("Hard", hardness)
    {
    }

    public override void DegradateTyre()
    {
        var currentDegradation = this.Degradation;

        currentDegradation -= this.Hardness;
        if (currentDegradation < 0)
        {
            throw new ArgumentException("Blown Tyre");
        }

        this.Degradation = currentDegradation;
    }
}