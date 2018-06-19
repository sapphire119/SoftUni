public class Product
{
    private string name;
    private decimal cost;

    public Product() { }

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }
    
    public decimal Cost
    {
        get
        {
            return this.cost;
        }
        set
        {
            if (value < 0M)
            {
                throw Exceptions.moneyException;
            }
            this.cost = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw Exceptions.nameException;
            }

            this.name = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }
}