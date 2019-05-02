using System.Collections.Generic;

public class AddRemoveCollection : IAddRemoveCollection
{
    private IList<string> elements;

    public AddRemoveCollection()
    {
        this.elements = new List<string>();
    }

    public IReadOnlyCollection<string> Elements => (IReadOnlyCollection<string>) this.elements;

    public int Add(string item)
    {
        this.elements.Insert(0, item);
        var index = 0;
        return index;
    }

    public string Remove(string item)
    {
        var itemToBeRemoved = this.elements[this.elements.Count - 1];
        this.elements.RemoveAt(this.elements.Count);
        return itemToBeRemoved;
    }
}