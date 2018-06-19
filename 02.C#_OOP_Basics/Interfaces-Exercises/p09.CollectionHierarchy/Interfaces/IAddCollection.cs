using System;
using System.Collections.Generic;

public interface IAddCollection
{
    IReadOnlyCollection<string> Elements { get; }

    int Add(string item);
}