using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestsPriorityQueue
{
    [TestMethod]
    public void DecreaseKey_SingleElement()
    {
        var queue = new PriorityQueue<TestNode<int>>();

        var testNode = new TestNode<int>() { Value = 1 };

        queue.Enqueue(testNode);
        queue.DecreaseKey(testNode);

        Assert.AreEqual(1, queue.Count);
        Assert.AreEqual(1, queue.Dequeue().Value);
    }

    [TestMethod]
    public void DecreaseKey_TwoElements()
    {
        var queue = new PriorityQueue<TestNode<int>>();

        var testNode1 = new TestNode<int>() { Value = 2 };
        var testNode2 = new TestNode<int>() { Value = 3 };

        queue.Enqueue(testNode1);
        queue.Enqueue(testNode2);

        testNode2.Value = 1;
        queue.DecreaseKey(testNode2);

        Assert.AreEqual(2, queue.Count);
        Assert.AreEqual(1, queue.Dequeue().Value);
    }

    [TestMethod]
    public void DecreaseKey_MultipleElements()
    {
        var queue = new PriorityQueue<TestNode<int>>();

        var testNode1 = new TestNode<int>() { Value = 6 };
        var testNode2 = new TestNode<int>() { Value = 3 };
        var testNode3 = new TestNode<int>() { Value = 4 };
        var testNode4 = new TestNode<int>() { Value = 2 };
        var testNode5 = new TestNode<int>() { Value = 8 };
        var testNode6 = new TestNode<int>() { Value = 13 };
        var testNode7 = new TestNode<int>() { Value = 9 };
        var testNode8 = new TestNode<int>() { Value = 10 };
        var testNode9 = new TestNode<int>() { Value = 12 };
        var testNode10 = new TestNode<int>() { Value = 14 };

        queue.Enqueue(testNode1);
        queue.Enqueue(testNode2);
        queue.Enqueue(testNode3);
        queue.Enqueue(testNode4);
        queue.Enqueue(testNode5);
        queue.Enqueue(testNode6);
        queue.Enqueue(testNode7);
        queue.Enqueue(testNode8);
        queue.Enqueue(testNode9);
        queue.Enqueue(testNode10);

        testNode5.Value = 1;
        queue.DecreaseKey(testNode5);

        Assert.AreEqual(1, queue.Dequeue().Value);
        Assert.AreEqual(2, queue.Dequeue().Value);

        testNode1.Value = 1;
        queue.DecreaseKey(testNode1);
        Assert.AreEqual(1, queue.Dequeue().Value);
    }

    [TestMethod]
    public void DecreaseKey_Multiple()
    {
        var queue = new PriorityQueue<TestNode<int>>();

        var testNode1 = new TestNode<int>() { Value = 42 };
        var testNode2 = new TestNode<int>() { Value = 48 };
        var testNode3 = new TestNode<int>() { Value = 48 };
        var testNode4 = new TestNode<int>() { Value = 48 };
        var testNode5 = new TestNode<int>() { Value = 54 };
        var testNode6 = new TestNode<int>() { Value = 68 };
        var testNode7 = new TestNode<int>() { Value = 68 };
        var testNode8 = new TestNode<int>() { Value = 62 };
        var testNode9 = new TestNode<int>() { Value = 70 };

        queue.Enqueue(testNode1);
        queue.Enqueue(testNode2);
        queue.Enqueue(testNode3);
        queue.Enqueue(testNode4);
        queue.Enqueue(testNode5);
        queue.Enqueue(testNode6);
        queue.Enqueue(testNode7);
        queue.Enqueue(testNode8);
        queue.Enqueue(testNode9);

        testNode6.Value = 60;
        queue.DecreaseKey(testNode5);
        ;
    }
}

class TestNode<T> : IComparable<TestNode<T>> where T : IComparable<T>
{
    public T Value { get; set; }

    public int CompareTo(TestNode<T> other)
    {
        return this.Value.CompareTo(other.Value);
    }

    public override string ToString()
    {
        return this.Value.ToString();
    }
}
