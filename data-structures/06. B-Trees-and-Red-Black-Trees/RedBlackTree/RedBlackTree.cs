using System;
using System.Collections.Generic;

public class RedBlackTree<T> : IBinarySearchTree<T> where T : IComparable
{
    private Node root;
    private const bool Red = true;
    private const bool Black = false;

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

    private Node Insert(T element, Node node, Node previousNode = null)
    {
        if (node == null)
        {
            node = new Node(element, Red, previousNode);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left, node);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right, node);
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

    private int Count(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Count;
    }

    private RedBlackTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    public RedBlackTree()
    {
    }

    public void Insert(T element)
    {
        //root is black
        //only red or black nodes
        //nulls are black
        //cannot have two consquitve red nodes
        //Every path from root-leaf must have the same number of black nodes
        //Every insertion is a red node
        this.root = this.Insert(element, this.root);

        SetRootBlack(this.root);
        //BalanceTree();

        ResolveNode(this.root, element);
        //check for conflicts


        //when adding a node we should check if there are two consequite reds
        //if there are check aunt 
        //if aunt is red -> ColorFlip
        //if aunt is black -> rotate
        //  after rotate -> fix colors

        //check if tree violetes any rule: (has two consecutive RED nodes) (root is not black)
        //if there are -> find the conflict node
        //get its parent and grandparent, look at the aunt
        //    if last node is Left look at right subNode aunt
        //    if last node is Right look at left subNode aunt
        //if aunt is red -> ColourFlip
        //if aunt is black -> Rotate
        //if ROTATION
        //Determine Directions with method IsInLeft(parent)
        //var leftParent = ...;
        //var leftGrandParent = ...;
        //if left, left -> Right rotate
        //if right, right -> Left rotate
        //if left, right -> L-R 
        //  check notes
        //if right, left -> R-L rotate
        //  check notes

        //check if tree has confclits
        //if none -> return tree;



        //var node = this.FindElement(element);
        //CheckNode(node);

        //CheckTree(this.root);
        //while (true)
        //{
        //    var isRootRed = IsRed(this.root);
        //    var areThereTwoConsequtiveRedNodes = AreThereTwoConsequtiveRedNodes(this.root);
        //    var areNumberOfBlackNodesSameCount = AreNumberOfBlackNodesSameCount(this.root);

        //    if (areThereTwoConsequtiveRedNodes)
        //    {

        //    }

        //    if (!areNumberOfBlackNodesSameCount)
        //    {


        //    }

        //    if (isRootRed)
        //    {

        //    }



        //    if (!isRootRed && areNumberOfBlackNodesSameCount && !areThereTwoConsequtiveRedNodes)
        //    {
        //        break;
        //    }
        //}

        //cannot have two consequite red nodes
        //root needs to be black
        //count of root-leaf should be the same
        //nulls are black --> IsRed() method


    }

    private void SetRootBlack(Node root)
    {
        if (IsRed(this.root)) this.root.Color = Black;
    }

    private void ResolveNode(Node node, T elementValue)
    {
        if (node == null)
        {
            return;
        }

        var comparison = elementValue.CompareTo(node.Value);

        if (comparison < 0)
        {
            this.ResolveNode(node.Left, elementValue);
        }
        else if(comparison > 0)
        {
            this.ResolveNode(node.Right, elementValue);
        }
        else
        {
            if (IsRed(node.PreviousNode) && IsRed(node))
            {
                var child = node;
                var parent = node.PreviousNode;
                var grandParent = node.PreviousNode.PreviousNode;

                var isChildLeft = IsInLeftChild(parent, child);
                var isParentLeft = IsInLeftChild(grandParent, parent);

                var isAuntRedNode = IsAuntRed(grandParent, isParentLeft);

                if (isAuntRedNode)
                {
                    FlipColours(grandParent);

                    this.SetRootBlack(this.root);

                    this.ResolveNode(this.root, grandParent.Value);
                }
                else
                {
                    Rotate(isChildLeft, isParentLeft, grandParent);

                    if ((isChildLeft && isParentLeft) || (!isChildLeft && !isParentLeft))
                    {
                        AfterRotationFlip(parent);
                        this.ResolveNode(this.root, parent.Value);
                        //this.ResolveNode(this.root, parent.Value);
                    }
                    else
                    {
                        AfterRotationFlip(child);
                        this.ResolveNode(this.root, child.Value);
                        //this.ResolveNode(this.root, child.Value);
                    }
                    //Rotate
                    //FixColors
                }
                //if (isChildLeft && isParentLeft) RotateLeft(grandParent);
                //if (!isChildLeft && !isParentLeft) RotateRight(grandParent);
                //if (!isChildLeft && isParentLeft) /*R-L rotate*/ 
                //if (isChildLeft && !isParentLeft) L-R rotate
            }
        }
    }

    private void Rotate(bool isChildLeft, bool isParentLeft, Node grandParent)
    {
        var previousGpNode = grandParent.PreviousNode;

        if (isChildLeft && isParentLeft)
        {
            grandParent = RotateRight(grandParent);

            FixLeftRefsAfterRotate(previousGpNode, grandParent);
        }
        else if (!isChildLeft && !isParentLeft)
        {
            grandParent = RotateLeft(grandParent);

            FixRightRefsAfterRotate(previousGpNode, grandParent);
        }
        else if (isChildLeft && !isParentLeft) //R-L rotate{
        {
            grandParent.Right = RotateRight(grandParent.Right);
            grandParent.Right.PreviousNode = grandParent;

            grandParent = RotateLeft(grandParent);

            FixRightRefsAfterRotate(previousGpNode, grandParent);
        }
        else if (!isChildLeft && isParentLeft) //L-R rotate
        {
            grandParent.Left = RotateLeft(grandParent.Left);
            grandParent.Left.PreviousNode = grandParent;

            grandParent = RotateRight(grandParent);

            FixLeftRefsAfterRotate(previousGpNode, grandParent);
        }
    }

    private void FixLeftRefsAfterRotate(Node previousNode, Node grandParent)
    {
        if (previousNode != null)
        {
            previousNode.Left = grandParent; 
        }
        grandParent.PreviousNode = previousNode;
    }

    private void FixRightRefsAfterRotate(Node previousNode, Node grandParentNode)
    {
        if (previousNode != null)
        {
            previousNode.Right = grandParentNode;
        }
        grandParentNode.PreviousNode = previousNode;
    }

    private bool IsAuntRed(Node grandParent, bool isParentLeft)
    {
        if (isParentLeft)
        {
            return IsRed(grandParent.Right);
        }
        else
        {
            return IsRed(grandParent.Left);
        }
    }

    public void SandBox(Node node)
    {
        Rotate(true, false, node);
        //var test = this.IsAuntRed(this.root, IsInLeftChild(this.root, this.root.Left));
        //var test1 = this.IsAuntRed(this.root, IsInLeftChild(this.root, this.root.Right));
    }

    public void CheckNode(Node node)
    {

    }

    public bool IsInLeftChild(Node parent, Node current)
    {
        if (parent.Left == current)
        {
            return true;
        }

        return false;
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

    public IBinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new RedBlackTree<T>(current);
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

    public virtual void Delete(T element)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }
        this.root = this.Delete(element, this.root);
    }

    private Node Delete(T element, Node node)
    {
        if (node == null)
        {
            return null;
        }

        int compare = element.CompareTo(node.Value);

        if (compare < 0)
        {
            node.Left = this.Delete(element, node.Left);
        }
        else if (compare > 0)
        {
            node.Right = this.Delete(element, node.Right);
        }
        else
        {
            if (node.Right == null)
            {
                return node.Left;
            }
            if (node.Left == null)
            {
                return node.Right;
            }

            Node temp = node;
            node = this.FindMin(temp.Right);
            node.Right = this.DeleteMin(temp.Right);
            node.Left = temp.Left;

        }
        node.Count = this.Count(node.Left) + this.Count(node.Right) + 1;

        return node;
    }

    private Node FindMin(Node node)
    {
        if (node.Left == null)
        {
            return node;
        }

        return this.FindMin(node.Left);
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

    public int Count()
    {
        return this.Count(this.root);
    }

    public int Rank(T element)
    {
        return this.Rank(element, this.root);
    }

    private int Rank(T element, Node node)
    {
        if (node == null)
        {
            return 0;
        }

        int compare = element.CompareTo(node.Value);

        if (compare < 0)
        {
            return this.Rank(element, node.Left);
        }

        if (compare > 0)
        {
            return 1 + this.Count(node.Left) + this.Rank(element, node.Right);
        }

        return this.Count(node.Left);
    }

    public T Select(int rank)
    {
        Node node = this.Select(rank, this.root);
        if (node == null)
        {
            throw new InvalidOperationException();
        }

        return node.Value;
    }

    private Node Select(int rank, Node node)
    {
        if (node == null)
        {
            return null;
        }

        int leftCount = this.Count(node.Left);
        if (leftCount == rank)
        {
            return node;
        }

        if (leftCount > rank)
        {
            return this.Select(rank, node.Left);
        }
        else
        {
            return this.Select(rank - (leftCount + 1), node.Right);
        }
    }

    public T Ceiling(T element)
    {

        return this.Select(this.Rank(element) + 1);
    }

    public T Floor(T element)
    {
        return this.Select(this.Rank(element) - 1);
    }

    private bool IsRed(Node node)
    {
        if (node == null)
        {
            return false;
        }

        return node.Color == Red;
    }

    private Node RotateLeft(Node currentNode)
    {
        Node temp = currentNode;
        Node node = temp.Right;

        temp.Right = null;
        temp.PreviousNode = null;
        node.Left = SetLeftNode(temp, node.Left);
        node.Left.PreviousNode = node;

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);
        node.PreviousNode = null;

        return node;
    }

    private Node SetLeftNode(Node temp, Node left)
    {
        if (left != null)
        {
            left.PreviousNode = null; 
        }
        temp.Right = left;

        if (temp.Right != null)
        {
            temp.Right.PreviousNode = temp; 
        }

        return temp;
    }

    private Node RotateRight(Node currentNode)
    {
        Node temp = currentNode;
        Node node = temp.Left;

        temp.Left = null;
        temp.PreviousNode = null;
        node.Right = SetRightNode(temp, node.Right);
        node.Right.PreviousNode = node;

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);
        node.PreviousNode = null;


        return node;
    }

    private Node SetRightNode(Node temp, Node right)
    {
        if (right != null)
        {
            right.PreviousNode = null; 
        }
        temp.Left = right;

        if (temp.Left != null)
        {
            temp.Left.PreviousNode = temp; 
        }

        return temp;
    }

    private void AfterRotationFlip(Node node)
    {
        node.Color = Black;
        node.Left.Color = Red;
        node.Right.Color = Red;
    }

    private void FlipColours(Node node)
    {
        node.Color = Red;
        node.Left.Color = Black;
        node.Right.Color = Black;

        //return node;
    }

    public class Node
    {
        public Node(T value, bool color, Node previousNode)
        {
            this.Value = value;
            this.Color = color;
            this.PreviousNode = previousNode;
        }

        public T Value { get; }

        public bool Color { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node PreviousNode { get; set; }

        public int Count { get; set; }
    }

}

public class Launcher
{
    public static void Main(string[] args)
    {
        var rbt = new RedBlackTree<int>();

        //LEFT
        //rbt.Insert(3);
        //rbt.Insert(1);
        //rbt.Insert(6);
        //rbt.Insert(5);
        //rbt.Insert(8);
        //rbt.Insert(7);
        //rbt.Insert(8);
        //rbt.Insert(9);
        //rbt.Insert(10);

        //RIGHT
        //rbt.Insert(12);
        //rbt.Insert(14);
        //rbt.Insert(5);
        //rbt.Insert(6);
        //rbt.Insert(3);
        //rbt.Insert(8);
        //rbt.Insert(7);

        //RIGHT-LEFT
        //rbt.Insert(3);
        //rbt.Insert(2);
        //rbt.Insert(8);
        //rbt.Insert(1);
        //rbt.Insert(6);
        //rbt.Insert(5);
        //rbt.Insert(14);
        //rbt.Insert(7);
        //LEFT-RIGHT


        rbt.Insert(3);
        rbt.Insert(1);
        rbt.Insert(5);
        rbt.Insert(7);
        ;
        rbt.Insert(6);
        ;
        rbt.Insert(8);
        rbt.Insert(9);
        rbt.Insert(10);
        ;

        //var nodeToRotate = new RedBlackTree<int>.Node(3, true, null);
        //var nodeToRotate1 = new RedBlackTree<int>.Node(8, true, nodeToRotate);
        //var nodeToRotate2 = new RedBlackTree<int>.Node(6, true, nodeToRotate1);

        //nodeToRotate.Right = nodeToRotate1;
        //nodeToRotate1.Left = nodeToRotate2;

        //rbt.SandBox(nodeToRotate);

        //rbt.CheckNode(nodeToRotate);
    }
}
