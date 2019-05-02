using System;

public class Database : IDatabase
{
    private int[] values;
    private int currentIndex;

    public Database()
    {
        this.values = new int[16];
        this.currentIndex = -1;
    }

    public Database(params int[] inputNumbers)
        : this()
    {
        SetInputParams(inputNumbers);
    }

    private void SetInputParams(int[] inputNumbers)
    {
        if (inputNumbers == null) return;
        if (inputNumbers.Length > 16)
        {
            throw new InvalidOperationException($"Array's capacity must be 16!");
        }
        Array.Copy(inputNumbers, this.values, inputNumbers.Length);
        this.currentIndex = inputNumbers.Length - 1;
    }

    public void Add(int element)
    {
        if (this.currentIndex + 1 >= this.values.Length)
        {
            throw new InvalidOperationException("Array is full!");
        }
        this.currentIndex++;
        this.values[this.currentIndex] = element;
    }

    public int[] Fetch()
    {
        var arrayToFetch = new int[this.currentIndex + 1];
        Array.Copy(this.values, arrayToFetch, this.currentIndex + 1);
        return arrayToFetch;
    }

    public void Remove()
    {
        if (this.currentIndex < 0)
        {
            throw new InvalidOperationException("Array is empty!");
        }
        this.values[this.currentIndex] = 0;
        this.currentIndex--;
    }
}