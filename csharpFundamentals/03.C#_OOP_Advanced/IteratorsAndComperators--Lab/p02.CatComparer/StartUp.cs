using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        IComparer<Cat> comparer = new CatComparer();

        SortedSet<Cat> catsByname = new SortedSet<Cat>(comparer);

        var cat = new Cat("a", 12);
        var cat1 = new Cat("b", 13);
        var cat2 = new Cat("c", 14);
        var cat3 = new Cat("d", 15);

        Console.WriteLine();
        catsByname.Add(cat3);
        catsByname.Add(cat1);
        catsByname.Add(cat);
        catsByname.Add(cat2);
    }
}

