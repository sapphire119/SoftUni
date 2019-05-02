using System;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip)
        : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public double Grip
    {
        get
        {
            return this.grip;
        }
        private set
        {
            this.grip = value;
        }
    }

    public override void DegradateTyre()
    {
        var currentDegradation = this.Degradation;

        double degradationForLaps = (this.Hardness + this.Grip);

        currentDegradation -= degradationForLaps;
        if (currentDegradation < 30.0)
        {
            throw new ArgumentException("Blown Tyre");
        }
        this.Degradation = currentDegradation;
    }
}
