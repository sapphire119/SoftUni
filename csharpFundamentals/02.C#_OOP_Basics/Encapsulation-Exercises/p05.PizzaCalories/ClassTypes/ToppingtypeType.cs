using System.Collections.Generic;

public class ToppingtypeType
{
    //meat, veggies, cheese or sauce
    public static Dictionary<string, decimal> ToppingTypes = new Dictionary<string, decimal>()
    {
        { "meat", 1.2M },
        { "veggies", 0.8M },
        { "cheese", 1.1M },
        { "sauce", 0.9M }
    };
}