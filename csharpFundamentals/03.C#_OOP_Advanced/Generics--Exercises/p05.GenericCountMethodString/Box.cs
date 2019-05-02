using System;

public class Box<T> : IComparable<Box<T>>
    where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public int CompareTo(Box<T> otherBox)
    {
        return this.value.CompareTo(otherBox.value);
    }

    public override string ToString()
    {
        return $"{value.GetType()}: {value}";
    }
}