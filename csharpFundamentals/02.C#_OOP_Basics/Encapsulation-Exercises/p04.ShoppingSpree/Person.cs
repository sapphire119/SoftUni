using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts = new List<Product>();

    public Person() { }

    public Person(string name, decimal money)
        : this()
    {
        this.Name = name;
        this.Money = money;
    }

    public IReadOnlyCollection<Product> BagOfProducts
    {
        get
        {
            return this.bagOfProducts;
        }
    }

    public decimal Money
    {
        get
        {
            return this.money;
        }
        set
        {
            if (value < 0M)
            {
                throw Exceptions.moneyException;
            }
            this.money = value;
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

    public void AddProduct(Product product)
    {
        this.bagOfProducts.Add(product);
    }

    public override string ToString()
    {
        var endMessageForProducts = this.bagOfProducts.Count != 0 ? string.Join(", ", this.bagOfProducts) : "Nothing bought";
        return $"{this.Name} - {endMessageForProducts}";
    }
}