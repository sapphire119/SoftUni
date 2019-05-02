using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    Random random = new Random();

    public string RandomString()
    {
        var randomIndex = random.Next(0, this.Count);

        var elementToRemove = this[randomIndex];
        this.RemoveAt(randomIndex);

        return elementToRemove;
    }
}