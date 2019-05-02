using System;
using System.Collections.Generic;

public class Comparer : IComparer
{
    public int Compare<T>(List<T> list, T element)
        where T : IComparable<T>
    {
        var result = 0;

        foreach (var item in list)
        {
            var comparisonResult =  item.CompareTo(element);

            if (comparisonResult > 0)
            {
                result++;
            }
        }

        return result;
    }
}
