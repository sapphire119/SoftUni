using System;
using System.Linq;

public static class SortedClass
{
    public static CustomList<T> Sort<T>(CustomList<T> list)
        where T : IComparable<T>
    {
        var newList = new CustomList<T>();
        foreach (var item in list.OrderBy(e => e))
        {
            newList.Add(item);
        }

        list = new CustomList<T>();
        list = newList;

        return list;
    }
}