using System.Collections.Generic;

public class Box<T>
{
    private List<T> items;

    public Box()
    {
        this.items = new List<T>();
    }

    public void Add(T element) => this.items.Add(element);

    public T Remove()
    {
        var lastElement = this.items[this.items.Count - 1];
        this.items.RemoveAt(this.items.Count - 1);
        return lastElement;
    }

    public int Count => this.items.Count;
}