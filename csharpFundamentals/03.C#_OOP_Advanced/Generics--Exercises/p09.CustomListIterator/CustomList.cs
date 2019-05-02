using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class CustomList<T> : ICustomList<T>, IEnumerable<T>
    where T : IComparable<T>
{
    private IList<T> list;

    public CustomList()
    {
        this.list = new List<T>();
    }

    public void Add(T element)
    {
        this.list.Add(element);
    }

    public bool Contains(T element)
    {
        return this.list.Contains(element);
    }

    public int CountGreaterThan(T element)
    {
        var countElements = 0;

        foreach (var item in this.list)
        {
            var comparisonResult = item.CompareTo(element);

            if (comparisonResult > 0)
            {
                countElements++;
            }
        }

        return countElements;
    }

    public T Max()
    {
        return this.list.Max();
    }

    public T Min()
    {
        return this.list.Min();
    }

    public T Remove(int index)
    {
        var elementToRemove = this.list[index];

        this.list.RemoveAt(index);

        return elementToRemove;
    }

    public void Swap(int index1, int index2)
    {
        bool isFirstIndexInsideList = (0 <= index1 && index1 < this.list.Count);

        bool isSecondIndexInsideList = (0 <= index2 && index2 < this.list.Count);

        if (!isFirstIndexInsideList || !isSecondIndexInsideList)
        {
            return;
        }

        var temp = this.list[index1];
        this.list[index1] = this.list[index2];
        this.list[index2] = temp;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.list.GetEnumerator();
    }
}