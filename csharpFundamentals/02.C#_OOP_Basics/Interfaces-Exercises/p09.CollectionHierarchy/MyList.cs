using System.Collections.Generic;

public class MyList : IMyList
{
    private IList<string> elements;

    public MyList()
    {
        this.elements = new List<string>();
    }

    public IReadOnlyCollection<string> Elements => (IReadOnlyCollection<string>)this.elements;

    public void Add(string item)
    {
        this.elements.Insert(0, item);
    }

    public string Remove(string item)
    {
        var itemToBeRemoved = this.elements[0];
        this.elements.RemoveAt(0);
        return itemToBeRemoved;
    }

    public int Used(string item)
    {
        return this.elements.Count;
    }
}