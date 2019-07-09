using System;
using System.Collections.Generic;

public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
{
    private Node root;

    private Node FindElement(T element)
    {
        Node current = this.root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    private void PreOrderCopy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.PreOrderCopy(node.Left);
        this.PreOrderCopy(node.Right);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right);
        }

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return node;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (nodeInHigherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
    }
    
    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private BinarySearchTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
    }
    
    public void Insert(T element)
    {
        this.root = this.Insert(element, this.root);
    }
    
    public bool Contains(T element)
    {
        Node current = this.FindElement(element);

        return current != null;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        this.root = this.DeleteMin(this.root);
    }

    private Node DeleteMin(Node node)
    {
        if (node.Left == null)
        {
            return node.Right;
        }

        node.Left = this.DeleteMin(node.Left);

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return node;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    public void Delete(T element)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        this.Delete(this.root, element);
        ;
    }

    private void Delete(Node node, T element, Node previousNode = null)
    {

        if (node.Left != null)
        {
            this.Delete(node.Left, element, node);
        }

        if (element.CompareTo(node.Value) == 0)
        {
            if (node.Right != null)
            {
                var deletionNode = node.Right;
                Node currentNode = null;

                while (deletionNode.Left != null)
                {
                    currentNode = deletionNode;
                    deletionNode = deletionNode.Left;
                }

                if (deletionNode.Right != null && currentNode != null)
                {
                    currentNode.Left = deletionNode.Right;
                    deletionNode.Right = currentNode;
                }
                else if(deletionNode.Right == null && currentNode != null)
                {
                    currentNode.Left = null;
                }

                Node tempNodeLeft = node.Left;
                Node tempNodeRight = node.Right;

                node = deletionNode;

                node.Left = tempNodeLeft;
                //Check 3;
                //Check 37;
                if (tempNodeRight != null && node.Value.CompareTo(tempNodeRight.Value) != 0)
                {
                    node.Right = tempNodeRight; 
                }

                if (previousNode != null && previousNode.Value.CompareTo(node.Value) > 0)
                {
                    previousNode.Left = node; 
                }
                else if (previousNode != null && previousNode.Value.CompareTo(node.Value) < 0)
                {
                    previousNode.Right = node;
                }

                if (previousNode == null)
                {
                    this.root = node;
                }
            }
            else if (node.Left != null)
            {
                var deletionNode = node.Left;
                Node currentNode = null;

                while (deletionNode.Right != null)
                {
                    currentNode = deletionNode;
                    deletionNode = deletionNode.Right;
                }

                //deletionNode.Right != null && !currentNode.Value.Equals(deletionNode.Value)

                if (deletionNode.Left != null && currentNode != null)
                {
                    currentNode.Right = deletionNode.Left;
                    deletionNode.Left = currentNode;
                }
                else if(deletionNode.Left == null && currentNode != null)
                {
                    currentNode.Right = null;
                }

                Node tempNodeLeft = node.Left;
                Node tempNodeRight = node.Right;

                node = deletionNode;

                node.Right = tempNodeRight;
                
                if (tempNodeLeft != null && node.Value.CompareTo(tempNodeLeft.Value) != 0)
                {
                    node.Left = tempNodeLeft;
                    
                }
                //node.Left = tempNodeLeft;
                //node.Right = tempNodeRight;

                if (previousNode != null && previousNode.Value.CompareTo(node.Value) > 0)
                {
                    previousNode.Left = node;
                }
                else if (previousNode != null && previousNode.Value.CompareTo(node.Value) < 0)
                {
                    previousNode.Right = node;
                }

                if (previousNode == null)
                {
                    this.root = node;
                }
            }
            else
            {
                if (previousNode != null)
                {
                    if (node.Value.CompareTo(previousNode.Value) > 0)
                    {
                        previousNode.Right = null;
                    }
                    else if (node.Value.CompareTo(previousNode.Value) < 0)
                    {
                        previousNode.Left = null;
                    } 
                }
                else
                {
                    this.root = null;
                }
            }
            //Delete element
        }

        if (node.Right != null)
        {
            this.Delete(node.Right, element, node);
        }
    }

    public void DeleteMax()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        this.root = this.DeleteMax(this.root);
    }

    private Node DeleteMax(Node node)
    {
        if (node.Right == null)
        {
            return node.Left;
        }

        node.Right = this.DeleteMax(node.Right);

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return node;
    }

    private int Count(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Count;
    }

    public int Count()
    {
        return this.Count(this.root);
    }

    private int Rank(T element, Node node /*, int rankedCount*/)
    {
        if (node == null)
        {
            return 0;
        }

        var comparison = element.CompareTo(node.Value);

        if (comparison < 0)
        {
            return this.Rank(element, node.Left);
            //rankedCount += this.Rank(element, node.Left, 1);
            //rankedCount += this.Rank(element, node.Right, 1);
        }
        else if (comparison > 0)
        {
            return 1 + this.Count(node.Left) + this.Rank(element, node.Right);
            //rankedCount = this.Rank(element, node.Left, 0);
        }

        //return rankedCount;
        return this.Count(node.Left);
    }

    public int Rank(T element)
    {
        return this.Rank(element, this.root);
    }

    public T Select(int rank)
    {
        //if rank == 0  -> First element / Leftmost element, Print 1
        //if rank == 2  -> 1, 3 / Print 4
        //if rank == 4  -> 1, 3, 4, 5 / Print 8

        //if (rank == 0)
        //{

        //    var smallestNode = this.DeleteMin(this.root);

        //    this.Insert(smallestNode.Value);

        //    return smallestNode.Value;
        //}

        Node node = this.Select(this.root, rank);

        if (node == null)
        {
            throw new InvalidOperationException();
        }

        return node.Value;
    }

    private Node Select(Node node, int rank)
    {
        if (node == null)
        {
            return null;
        }

        var leftCount = this.Count(node.Left);

        if (leftCount.CompareTo(rank) > 0)
        {
            return this.Select(node.Left, rank);
        }
        else if(leftCount.CompareTo(rank) < 0)
        {
            return this.Select(node.Right, rank - (leftCount + 1));
        }

        return node;
    }

    //private T Select(Node node, int rank)
    //{

    //    ////Put all Values into array
    //    //Node[] nodes = new Node[1];
    //    //FetchNodeByRank(node, rank, 0, nodes);

    //    //return nodes[0].Value;
    //}

    //private int FetchNodeByRank(Node node, int rank, int count, Node[] returnNodes)
    //{
    //    //Put all Values into array
    //    if (node.Left != null)
    //    {
    //        count = this.FetchNodeByRank(node.Left, rank, count, returnNodes);
    //    }

    //    if (rank == count)
    //    {
    //        returnNodes[0] = node;
    //    }

    //    count++;

    //    if (node.Right != null)
    //    {
    //        count = this.FetchNodeByRank(node.Right, rank, count, returnNodes);
    //    }

    //    return count;
    //}

    public T Ceiling(T element)
    {
        //Node node = this.Ceiling(this.root, element);

        //if (/*node == null*/ this.root == null)
        //{
        //    throw new InvalidOperationException();
        //}

        return this.Select(this.Rank(element) + 1);
        //return node.Value;
    }

    private Node Ceiling(Node node, T element)
    {
        if (node == null)
        {
            return null;
        }

        Node nodeToReturn = null;
        if (node.Left != null)
        {
            nodeToReturn = this.Ceiling(node.Left, element);
        }

        if (element.CompareTo(node.Value) < 0 && nodeToReturn == null)
        {
            return node;
        }

        if (node.Right != null && nodeToReturn == null)
        {
            nodeToReturn = this.Ceiling(node.Right, element);
        }

        return nodeToReturn;
    }

    public T Floor(T element)
    {
        Node node = this.Floor(this.root, element);

        if (node == null)
        {
            throw new InvalidOperationException();
        }
        return this.Select(this.Rank(element) - 1);
        return node.Value;
    }

    private Node Floor(Node node, T element)
    {
        if (node == null)
        {
            return null;
        }

        if (element.CompareTo(node.Value) <= 0)
        {
            return this.Floor(node.Left, element);
        }

        var nodeToReturn = this.Floor(node.Right, element);
        if (nodeToReturn == null)
        {
            nodeToReturn = node;
        }

        return nodeToReturn;
    }

    //private T Floor(T element, Node node)
    //{
    //    //Put all Values into array
    //    if (this.root == null)
    //    {
    //        return default(T);
    //    }

    //    Node current = this.root;
    //    Node parent = null;

    //    while (current.Value.CompareTo(element) >= 0)
    //    {
    //        parent = current;
    //        current = current.Left;
    //    }

    //    ;

    //    return default;
    //}

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public int Count { get; set; }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        var element = bst.Select(8);

        Console.WriteLine(element);
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(41);
        bst.Insert(47);
        //bst.Insert(57);
        //bst.Insert(34);
        //bst.Insert(30);
        //bst.Insert(33);
        //bst.Insert(32);
        //bst.Insert(38);
        //bst.Insert(40);
        //bst.Insert(39);
        //bst.Insert(46);
        //bst.Insert(50);
        //bst.Insert(58);
        //bst.Insert(20);
        //bst.Insert(19);
        //bst.Insert(24);
        //bst.Insert(22);
        //bst.Insert(28);
        //bst.Insert(26);
        //bst.Insert(27);


        //Console.WriteLine(bst.Rank(8));
        //Console.WriteLine("Before: ");
        //bst.EachInOrder(Console.WriteLine);
        //Console.WriteLine();
        //bst.Delete(10);
        //bst.Delete(37);
        //bst.Delete(20);
        //Console.WriteLine("After: ");
        //bst.EachInOrder(Console.WriteLine);
        //Console.WriteLine(result);
        //bst.EachInOrder(Console.WriteLine);

        //bst.DeleteMin();

        //bst.DeleteMax();
        //Console.WriteLine(bst.Select(3));

        //bst.Floor(5);

        //Console.WriteLine(bst.Rank(100));

        //Console.WriteLine(bst.Count());
    }
}