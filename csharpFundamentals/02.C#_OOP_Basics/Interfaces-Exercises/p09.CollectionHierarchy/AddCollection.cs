using System;
using System.Collections.Generic;

public class AddCollection : IAddCollection
{
    private IList<string> elements;

    public AddCollection()
    {
        this.elements = new List<string>();
    }

    public IReadOnlyCollection<string> Elements => (IReadOnlyCollection<string>) this.elements;

    public int Add(string item)
    {
        this.elements.Add(item);
        int currentIndex = this.elements.Count - 1;
        return currentIndex;
    }
}