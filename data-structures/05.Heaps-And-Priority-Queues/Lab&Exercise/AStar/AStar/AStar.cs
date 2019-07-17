using System;
using System.Linq;
using System.Collections.Generic;

public class AStar
{
    private const string StartSymbol = "P";
    private const string EndSymbol = "*";

    private const int NormalStep = 10;
    private const int DiagonalStep = 14;

    private char[,] Map { get; set; }

    private Node[,] NodeMap { get; set; }

    public AStar(char[,] map)
    {
        this.Map = map;
        this.NodeMap = new Node[map.GetLength(0), map.GetLength(1)];
    }

    public static int GetH(Node current, Node goal)
    {
        var width = GetWidthValToNode(current, goal);
        var height = GetHeightValToNode(current, goal);

        var result = width + height;

        return result;
        //return CalculateFCosts(height, width);
    }

    public static int GetG(Node current, Node previousNode)
    {
        if (!current.Equals(previousNode))
        {
            var height = GetHeightValToNode(current, previousNode);
            var width = GetWidthValToNode(current, previousNode);


            //var aculumatedGCost = previousNode.Gcost + CalculateFCosts(height, width);
            var aculumatedGCost = previousNode.Gcost + height + width;

            return aculumatedGCost;
        }

        return current.Gcost;
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        Node nodeGoal = null;
        try
        {
            nodeGoal = this.NodeMap[goal.Row, goal.Column];
        }
        catch (IndexOutOfRangeException e)
        {
            return new List<Node> { start };
        }

        if (nodeGoal == null)
        {
            var height = GetHeightValToNode(start, goal);
            var width = GetWidthValToNode(start, goal);

            SetStartingFCost(start, goal, height, width);

            var priorityQueue = new PriorityQueue<Node>();

            //FindPath(start, goal, priorityQueue, start);
            FindSimplePath(start, goal, priorityQueue, start);

            nodeGoal = goal;
        }

        var pathNodes = GetPathNodes(nodeGoal, start);
        
        return pathNodes.Reverse();
    }

    private void FindSimplePath(Node start, Node goal, PriorityQueue<Node> priorityQueue, Node newNodeStart = default(Node),
        bool isGoalFound = false)
    {
        var startRow = newNodeStart.Row - 1 >= 0 ? newNodeStart.Row - 1 : newNodeStart.Row;
        var endRow = newNodeStart.Row + 1 < this.Map.GetLength(0) ? newNodeStart.Row + 1 : newNodeStart.Row;

        var startColumn = newNodeStart.Column - 1 >= 0 ? newNodeStart.Column - 1 : newNodeStart.Column;
        var endColumn = newNodeStart.Column + 1 < this.Map.GetLength(1) ? newNodeStart.Column + 1 : newNodeStart.Column;


        for (int row = startRow; row <= endRow; row++)
        {
            var currentCol = newNodeStart.Column;

            char mapCell = this.Map[row, currentCol];
            Node currentCellNode = this.NodeMap[row, currentCol];

            if (row == newNodeStart.Row && !isGoalFound)
            {
                for (int column = startColumn; column <= endColumn; column++)
                {
                    mapCell = this.Map[row, column];
                    currentCellNode = this.NodeMap[row, column];

                    isGoalFound = FindGoal(currentCellNode, mapCell, newNodeStart, row, column, priorityQueue, goal);

                    if (isGoalFound)
                    {
                        return;
                    }
                }
            }
            else
            {
                isGoalFound = FindGoal(currentCellNode, mapCell, newNodeStart, row, currentCol, priorityQueue, goal);
            }

            if (isGoalFound)
            {
                return;
            }
        }

        FindSimplePath(start, goal, priorityQueue, priorityQueue.Dequeue());
    }

    private bool FindGoal(Node currentCellNode, char mapCell, Node newNodeStart, int row, int column, 
        PriorityQueue<Node> priorityQueue, Node goal)
    {
        if (currentCellNode == null && mapCell != 'P' && mapCell != 'W')
        {
            currentCellNode = new Node(row, column);
            currentCellNode.Gcost = GetG(currentCellNode, newNodeStart);
            currentCellNode.Hcost = GetH(currentCellNode, goal);

            currentCellNode.Fcost = currentCellNode.Gcost + currentCellNode.Hcost;

            currentCellNode.PreviousNode = newNodeStart;

            this.NodeMap[row, column] = currentCellNode;

            priorityQueue.Enqueue(currentCellNode);
        }
        else if (currentCellNode != null && GetFcost(currentCellNode, newNodeStart, goal) < currentCellNode.Fcost)
        {
            currentCellNode.Gcost = GetG(currentCellNode, newNodeStart);
            currentCellNode.Hcost = GetH(currentCellNode, goal);

            currentCellNode.Fcost = currentCellNode.Gcost + currentCellNode.Hcost;

            currentCellNode.PreviousNode = newNodeStart;

            priorityQueue.DecreaseKey(currentCellNode);
        }
        else if (currentCellNode != null && currentCellNode.Equals(goal))
        {
            goal.Gcost = GetG(goal, newNodeStart);
            goal.Fcost = goal.Gcost + goal.Hcost;

            goal.PreviousNode = newNodeStart;
            return true;
        }

        return false;
    }

    private IEnumerable<Node> GetPathNodes(Node goal, Node start)
    {
        if (goal.PreviousNode == null)
        {
            return new List<Node>() { start };
        }

        var pathList = new List<Node>();

        while (goal != null)
        {
            pathList.Add(goal);
            goal = goal.PreviousNode;
        }

        return pathList;
    }

    private void FindPath(Node start, Node goal, PriorityQueue<Node> priorityQueue, Node newNodeStart = default(Node))
    {
        var startRow = newNodeStart.Row - 1 >= 0 ? newNodeStart.Row - 1 : newNodeStart.Row;
        var endRow = newNodeStart.Row + 1 < this.Map.GetLength(0) ? newNodeStart.Row + 1 : newNodeStart.Row;

        var startColumn = newNodeStart.Column - 1 >= 0 ? newNodeStart.Column - 1 : newNodeStart.Column;
        var endColumn = newNodeStart.Column + 1 < this.Map.GetLength(1) ? newNodeStart.Column + 1 : newNodeStart.Column;

        for (int row = startRow; row <= endRow; row++)
        {
            for (int column = startColumn; column <= endColumn; column++)
            {
                var mapCell = this.Map[row, column];
                var currentCellNode = this.NodeMap[row, column];

                if (currentCellNode == null && mapCell != '*' && mapCell != 'P' && mapCell != 'W')
                {
                    currentCellNode = new Node(row, column);
                    currentCellNode.Gcost = GetG(currentCellNode, newNodeStart);
                    currentCellNode.Hcost = GetH(currentCellNode, goal);

                    currentCellNode.Fcost = currentCellNode.Gcost + currentCellNode.Hcost;

                    currentCellNode.PreviousNode = newNodeStart;

                    this.NodeMap[row, column] = currentCellNode;

                    priorityQueue.Enqueue(currentCellNode);
                }
                else if(currentCellNode != null && GetFcost(currentCellNode, newNodeStart, goal) < currentCellNode.Fcost)
                {
                    currentCellNode.Gcost = GetG(currentCellNode, newNodeStart);
                    currentCellNode.Hcost = GetH(currentCellNode, goal);

                    currentCellNode.Fcost = currentCellNode.Gcost + currentCellNode.Hcost;

                    currentCellNode.PreviousNode = newNodeStart;

                    priorityQueue.DecreaseKey(currentCellNode);
                }
                else if (mapCell == '*')
                {
                    goal.Gcost = GetG(goal, newNodeStart);
                    goal.Fcost = goal.Gcost + goal.Hcost;

                    goal.PreviousNode = newNodeStart;
                    return;
                }
            }
        }

        FindPath(start, goal, priorityQueue, priorityQueue.Dequeue());
    }

    private int GetFcost(Node currentCell, Node start, Node goal)
    {
        var result = AStar.GetH(currentCell, goal) + AStar.GetG(currentCell, start);
        return result;
    }

    private static int GetWidthValToNode(Node firstNode, Node secondNode)
    {
        return Math.Abs(firstNode.Column - secondNode.Column);
    }

    private static int GetHeightValToNode(Node firstNode, Node secondNode)
    {
        return Math.Abs(firstNode.Row - secondNode.Row);
    }

    private void SetStartingFCost(Node start, Node goal, int height = 0, int width = 0)
    {
        var result = height + width;
        //var result = CalculateFCosts(height, width);

        start.Fcost = result;
        start.Hcost = result;

        goal.Fcost = result;
        goal.Hcost = 0;

        this.NodeMap[start.Row, start.Column] = start;
        this.NodeMap[goal.Row, goal.Column] = goal;
    }

    private static int CalculateFCosts(int height, int width)
    {
        if (width > height)
        {
            return CalculateHorizontalFcost(width, height);
        }
        else if (width < height)
        {
            return CalculateVerticalFcost(width, height);
        }
        else
        {
            return CalculateDiagonalFcost(width, height);
        }
    }

    private static int CalculateDiagonalFcost(int width, int height)
    {
        var diagonalFcost = height * DiagonalStep;

        return diagonalFcost;
    }

    private static int CalculateVerticalFcost(int width, int height)
    {
        var verticalSteps = height - width;

        var diagStepsFcost = width * DiagonalStep;
        var verticalStepsFcost = verticalSteps * NormalStep;

        var result = verticalStepsFcost + diagStepsFcost;

        return result;
    }

    private static int CalculateHorizontalFcost(int width, int height)
    {
        var horizontalStep = width - height;

        var diagStepsFcost = height * DiagonalStep;
        var horizontalStepsFcost = horizontalStep * NormalStep;

        var result = horizontalStepsFcost + diagStepsFcost;

        return result;
    }
}