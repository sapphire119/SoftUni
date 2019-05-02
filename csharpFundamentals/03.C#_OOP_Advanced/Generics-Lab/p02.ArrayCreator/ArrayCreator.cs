public static class ArrayCreator
{
    public static T[] Create<T>(int length, T item)
    {
        var array = new T[length];
        for (int count = 0; count < array.Length; count++)
        {
            array[count] = item;
        }

        return array;
    }
}