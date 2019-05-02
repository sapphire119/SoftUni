public class Pokemon
{
    private string name;
    private string element;
    private decimal health;

    public Pokemon() { }

    public Pokemon(string name, string element, decimal health)
    {
        this.Name = name;
        this.Element = element;
        this.Health = health;
    }

    public decimal Health
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = value;
        }
    }


    public string Element
    {
        get
        {
            return this.element;
        }
        set
        {
            this.element = value;
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
            this.name = value;
        }
    }

}