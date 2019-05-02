using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public IReadOnlyCollection<string> Data => this.data;

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public bool IsEmpty()
    {
        if (this.data.Count <= 0)
        {
            return true;
        }
        return false;
    }

    public string Peek()
    {
        string elementToShow = string.Empty;
        if (!IsEmpty())
        {
            elementToShow = this.data[this.data.Count - 1];
        }
        return elementToShow;
    }

    public string Pop()
    {
        var elementToShow = Peek();
        data.Remove(elementToShow);
        return elementToShow;
    }
}