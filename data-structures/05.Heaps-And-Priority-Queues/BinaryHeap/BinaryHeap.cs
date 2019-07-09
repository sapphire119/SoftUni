using System;
using System.Linq;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public void Insert(T item)
    {
        //root formula -> Root(i) = i - 1 /2;
        this.heap.Add(item);
        this.HeapifyUp(this.heap.Count - 1);
        //for (int currentRootIndex = 0; currentRootIndex < this.heap.Count; currentRootIndex++)
        //{
        //    var rootIndex = currentRootIndex;
        //    var leftEleIndex = 2 * currentRootIndex + 1;
        //    var rightEleIndex = 2 * currentRootIndex + 2;

        //    var root = this.heap[currentRootIndex];

        //    if (leftEleIndex < this.Count && root.CompareTo(this.heap[leftEleIndex]) < 0)
        //    {
        //        var temp = this.heap[leftEleIndex];
        //        this.heap[leftEleIndex] = root;
        //        this.heap[rootIndex] = temp;

        //        currentRootIndex = -1;
        //    }

        //    if (rightEleIndex < this.Count && root.CompareTo(this.heap[rightEleIndex]) < 0)
        //    {
        //        var temp = this.heap[rightEleIndex];
        //        this.heap[rightEleIndex] = root;
        //        this.heap[rootIndex] = temp;

        //        currentRootIndex = -1;
        //    }

        //}

        //Left ele -> Left = 2 * i + 1;
        //Right ele -> Right = 2 * i + 2;
    }

    private void Swap(int index, int parentIndex)
    {
        var temp = this.heap[index];
        this.heap[index] = this.heap[parentIndex];
        this.heap[parentIndex] = temp;
    }

    private int Parent(int index)
    {
        var currentParentIndex = (index - 1) / 2;
        return currentParentIndex;
    }

    private bool IsLess(int parentIndex, int index)
    {
        return this.heap[parentIndex].CompareTo(this.heap[index]) < 0;
    }

    private void HeapifyUp(int index)
    {
        while (index > 0 && IsLess(Parent(index), index))
        {
            this.Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private bool HasChild(int index)
    {
        T element = this.heap.ElementAtOrDefault(index);
        var result = !element.Equals(default(T));
        return result;
    }

    private int Left(int index)
    {
        var leftIndex = 2 * index + 1;

        return leftIndex;
    }

    private void HeapifyDown(int index)
    {
        //HEIGHT of heap >>>>>> this.heap.Count / 2
        while (index < this.heap.Count / 2)
        {
            int child = Left(index);

            if (HasChild(child + 1) && IsLess(child, child + 1))
            {
                child = child + 1;
            }

            if (IsLess(child, index))
            {
                break;
            }

            this.Swap(index, child);
            index = child;
        }
    }

    public T Peek()
    {
        return this.heap[0];
    }

    public T Pull()
    {
        if (this.heap.Count < 1)
        {
            throw new InvalidOperationException();
        }

        var maxEle = this.heap[0];

        this.Swap(0, this.heap.Count - 1);
        this.heap.RemoveAt(this.heap.Count - 1);
        this.HeapifyDown(0);

        return maxEle;
    }
}
