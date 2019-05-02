public class Ferrari : ICarCommand
{
    private const string FerrariModel = "488-Spider";

    public Ferrari(string driverName)
    {
        this.DriverName = driverName;
    }

    public string DriverName { get; private set; }

    public string PushGasPedal() => "Zadu6avam sA!";

    public string UseBrakes() => "Brakes!";

    public override string ToString()
    {
        //488 - Spider / Brakes!/ Zadu6avam sA!/ Bat Giorgi
        return $"{FerrariModel}/{this.UseBrakes()}/{this.PushGasPedal()}/{this.DriverName}";
    }
}