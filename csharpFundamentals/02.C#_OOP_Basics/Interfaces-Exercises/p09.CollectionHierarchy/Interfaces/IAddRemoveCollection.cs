using System;

public interface IAddRemoveCollection : IAddCollection
{
    string Remove(string item);
}