public class Cargo
{
    private decimal weight;
    private string type;

    public Cargo() { }

    public Cargo(decimal weight, string type)
        : this()
    {
        this.Weight = weight;
        this.Type = type;
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        set
        {
            this.type = value;
        }
    }

    public decimal Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            this.weight = value;
        }
    }

}