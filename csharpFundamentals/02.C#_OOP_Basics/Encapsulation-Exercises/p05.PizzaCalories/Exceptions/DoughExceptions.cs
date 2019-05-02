using System;

public class DoughExceptions
{
    public static ArgumentException InvalidDoughException = new ArgumentException("Invalid type of dough.");
    public static ArgumentException WeightException = new ArgumentException("Dough weight should be in the range [1..200].");
}