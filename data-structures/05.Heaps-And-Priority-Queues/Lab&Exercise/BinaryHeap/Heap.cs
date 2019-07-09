using System;
using System.Linq;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        var arrLength = arr.Length;
        for (int index = arrLength / 2; index >= 0; index--)
        {
            HeapifyUp(arr, index, arr.Length);
        }
        
        for (int index = 0; index < arr.Length; index++)
        {
            HeapifyDown(arr, index);
        }
        ;
    }

    private static void HeapifyUp(T[] arr, int index, int allowedMaxLengthOfArr)
    {
        //var test = new int[] { 5, 2, 0, -4, 3, 12 };

        var parentIndex = index;
        while (parentIndex >= 0)
        {
            var childIndex = 2 * parentIndex + 1;

            if (HasChild(childIndex + 1, arr, allowedMaxLengthOfArr) && IsLess(childIndex, childIndex + 1, arr))
            {
                childIndex = childIndex + 1;
            }
            if (HasChild(childIndex, arr, allowedMaxLengthOfArr) && arr[childIndex].CompareTo(arr[parentIndex]) > 0)
            {
                Swap(childIndex, parentIndex, arr);
            }

            parentIndex--;
        }
        //0 -> Count / 2
        ////4 2 1 3 5 --> 0
        ////4 5 1 3 2 --> 1

        //Count/2 --> 0
        ////Count / 2 = 5 / 2 = 2;
        ////2 --> 0 (3)

        ////2 --> test1[2] == 1; Left --> 2 * 2 + 1 == 5; Right --> 2 * 2 + 2 == 6; Outside Arr both Left & Right
        ////1 --> test1[1] == 4; Left --> 2 * 1 + 1 == 3; Right --> 2 * 2 + 2 == 4; Left = 3; Right = 5;
        
        //2 4 1 3 5;

        ////test1 = 2 5 1 3 4
        
        ////0 --> .....
        //2 5 1 3 4

        ////test1 = 

        //2 4 1 3 5;

        //2 5 1 3 4

        //5 2 1 3 4

        //5 4 1 3 2

    }

    private static void HeapifyDown(T[] arr, int index)
    {

        //Swap
        var newArraySize = arr.Length - (index + 1);

        Swap(newArraySize, 0, arr);
        //Remove
        //var element = arr[newArraySize];
        //resultingArr[index] = element;
        //Heapify
        HeapifyUp(arr, newArraySize / 2, newArraySize);

        //5 4 1 3 2 

        //2 4 1 3 5 Swap

        //2 4 1 3  Remove

        //4 2 1 3 Heapify

        //4 3 1 2 

        //2 3 1 4 Swap

        //2 3 1  Remove

        //3 2 1

        //1 2 3

        //1 2

        //2 1

        //1 2

        //1


        //result ---
        //1 2 3 4 5


    }

    private static void Swap(int index, int parentIndex, T[] arr)
    {
        var temp = arr[index];
        arr[index] = arr[parentIndex];
        arr[parentIndex] = temp;
    }

    private static bool IsLess(int parentIndex, int index, T[] arr)
    {
        return arr[parentIndex].CompareTo(arr[index]) < 0;
    }

    private static bool HasChild(int index, T[] arr, int allowedMaxLengthOfArr)
    {
        if (index < allowedMaxLengthOfArr)
        {
            return true;
        }

        return false;
        //T element = arr.ElementAtOrDefault(index);
        //var result = !element.Equals(default(T));
        //return result;
    }
}
