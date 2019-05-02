using System.Text;

public class Seat : ICar
{
    private string model;
    private string color;

    public Seat(string model, string color)
    {
        this.model = model;
        this.color = color;
    }

    //public string CarColor
    //{
    //    get
    //    {
    //        return this.carColor;
    //    }
    //    set
    //    {
    //        this.carColor = value;
    //    }
    //}

    //public string CarModel
    //{
    //    get
    //    {
    //        return this.carModel;
    //    }
    //    set
    //    {
    //        this.carModel = value;
    //    }
    //}

    public string Color() => this.color;

    public string Model() => this.model;

    public string Start() => "Engine start";

    public string Stop() => "Breaaak!";

    protected virtual string BatteriesMessage => string.Empty;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Color()} {this.GetType().Name} {this.Model()}{this.BatteriesMessage}")
            .AppendLine($"{this.Start()}")
            .AppendLine($"{this.Stop()}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}