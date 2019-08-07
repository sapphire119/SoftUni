using System;
using System.Collections.Generic;

public class RedBlackTree<T> : IBinarySearchTree<T> where T : IComparable
{
    private Node root;
    private Node currentNode;

    private Node deletionNode;
    private Node replacement;
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
            this.currentNode = node;
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
        this.root = this.Insert(element, this.root);
        this.root.Color = Black;
        InsertResolutionOfNode(this.currentNode);
    }

    private void InsertResolutionOfNode(Node node)
    {
        if (node == null)
        {
            return;
        }

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
                this.root.Color = Black;
                this.InsertResolutionOfNode(grandParent);
            }
            else
            {
                Rotate(isChildLeft, isParentLeft, grandParent);

                if ((isChildLeft && isParentLeft) || (!isChildLeft && !isParentLeft))
                {
                    SetNewRoot(parent);
                    AfterRotationFlipOfColors(parent);
                    this.InsertResolutionOfNode(parent);
                }
                else
                {
                    SetNewRoot(child);
                    AfterRotationFlipOfColors(child);
                    this.InsertResolutionOfNode(child);
                }
            }
        }
    }

    private void SetNewRoot(Node newRoot)
    {
        if (newRoot != null && newRoot.PreviousNode == null && (newRoot.Left == this.root || newRoot.Right == this.root))
        {
            this.root = newRoot;
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

        grandParent.Count = 1 + this.Count(grandParent.Left) + this.Count(grandParent.Right);
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
        this.root.Color = Black;
        DeletionResolutionOfNode(this.deletionNode, this.replacement);
    }

    private void DeletionResolutionOfNode(Node deletionNode, Node replacement)
    {
        Node x = null;

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
            ////Check Part 1 of the three initial steps, get "replacement" and "x"
            //if (node.Left == null && node.Right == null)
            //{
            //    //set x = null;
            //    //set replacement = null;
            //    //go to part 2 of steps
            //    //Part2OfInitialSteps(node, replacement, x);
            //}

            //if (node.Left == null || node.Right == null)
            //{
            //    //set replacement = node.Left == null ? node.Right : node.Left;
            //    //set x = replacement;
            //    //go to part 2 of steps
            //    //Part2OfInitialSteps(node, replacement, x);
            //}

            //if (node.Left != null && node.Right != null)
            //{
            //    //set replacemnt = this.FindMin(node.Right);
            //    //set x = replacement.Right;
            //    //go to part 2 of steps
            //    //Part2OfInitialSteps(node, replacement, x);
            //}
            ////Check Part 2 of the four initial steps
            ////set replacement = x;
            ////set node = replaceent;
            ////go to appropriate case if necessaary
            
            this.deletionNode = node;

            if (node.Right == null)
            {
                this.replacement = node.Left;
                return node.Left;
            }
            if (node.Left == null)
            {
                this.replacement = node.Right;
                return node.Right;
            }

            Node temp = node;

            node = this.FindMin(temp.Right);
            node.Right = this.DeleteMin(temp.Right);
            node.Left = temp.Left;


            this.replacement = node;
        }

        node.Count = this.Count(node.Left) + this.Count(node.Right) + 1;

        return node;
    }

    public void Part2OfInitialSteps(Node deletionNode, Node replacement, Node x)
    {
        if (IsRed(deletionNode) && (IsRed(replacement) || replacement == null))
        {
            return;
        }

        if (IsRed(deletionNode) && !IsRed(replacement))
        {
            replacement.Color = Red;
            //go to appropricate case
            //Cases()
        }

        if (!IsRed(deletionNode) && IsRed(replacement))
        {
            replacement.Color = Black;
            return;
        }

        if (!IsRed(deletionNode) && (!IsRed(replacement) || replacement == null))
        {
            //go to appropriate case
        }
    }

    public void Cases(Node x, Node w, Node replacement = null)
    {
        if (IsRed(x))
        {
            x.Color = Black;
            //Case 0
            //X is red
        }

        if (!IsRed(x) && IsRed(w))
        {
            w.Color = Black;
            x.PreviousNode.Color = Red;

            var isXLeftChild = IsInLeftChild(replacement, x);
            if (isXLeftChild)
            {
                x.PreviousNode = RotateLeft(x);
            }
            else
            {
                x.PreviousNode = RotateRight(x);
            }


            //Case 1
            //Node "x" is BLACK & "w" is RED
        }

        if (!IsRed(x) && !IsRed(w) && !IsRed(w.Left) && !IsRed(w.Right))
        {
            //Case 2
            //Node "x" is BLACK & "w" is BLACK & w.Left, w.Right == BLACK

        }

        if (!IsRed(x) && !IsRed(w) && (
            (IsInLeftChild(replacement, x) && IsRed(w.Left) && !IsRed(w.Right)) ||
            (!IsInLeftChild(replacement, x) && IsRed(w.Right) && !IsRed(w.Left)) )
            )
        {
            //Case 3
            //Node "x" is BLACK & its sibling "w" is BLACK &
            //   if "x" is the LEFT child, "w"'s LEFT child is RED & "w"'s RIGHT child is BLACK
            //   if "x" is the RIGHT child, "w"'s RIGHT child is RED & "w"'s LEFT child is BLACK
        }

        if (!IsRed(x) && !IsRed(w) && (
            (IsInLeftChild(replacement, x) && IsRed(w.Right)) ||
            (!IsInLeftChild(replacement, x) && IsRed(w.Left)))
            )
        {
            //Case 4
            //Node "x" is BLACK & its sibling "w" is BLACK &
            //   if "x" is the LEFT child, "w"'s RIGHT child is RED
            //   if "x" is the RIGHT child, "w"'s LEFT child is RED
        }
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

    private void AfterRotationFlipOfColors(Node node)
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

        rbt.Delete(10);
        //rbt.Delete(7);
        ;
    }
}
