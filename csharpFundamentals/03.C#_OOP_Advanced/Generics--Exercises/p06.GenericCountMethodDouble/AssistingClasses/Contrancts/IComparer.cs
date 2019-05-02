using System;
using System.Collections.Generic;

public interface IComparer
{
    int Compare<T>(List<T> list, T element) where T : IComparable<T>;
}