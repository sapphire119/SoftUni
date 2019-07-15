using System;
using System.Linq;
using System.Collections.Generic;

public class AStar
{
    private const string StartSymbol = "P";
    private const string EndSymbol = "*";

    private const int NormalStep = 10;
    private const int DiagonalStep = 14;

    public char[,] Map { get; private set; }

    public Node[,] NodeMap { get; set; }

    public AStar(char[,] map)
    {
        this.Map = map;
        this.NodeMap = new Node[map.GetLength(0), map.GetLength(1)];
    }

    //private void SetMap(char[,] map)
    //{

    //    for (int i = 0; i < map.GetLength(0); i++)
    //    {
    //        for (int j = 0; j < map.GetLength(1); j++)
    //        {
    //            if (map[i, j] == 'W')
    //            {
    //                continue;
    //            }
    //            this.Map[i, j] = new Node(i, j);
    //        }
    //    }
    //}

    public static int GetH(Node current, Node goal)
    {
        var width = GetWidthValToNode(current, goal);
        var height = GetHeightValToNode(current, goal);

        CalculateFCosts(height, width);


        return current.Hcost;
    }

    public static int GetG(Node current, Node goal)
    {

        return current.Hcost;
    }

    //public static int GetGCost(Node current, Node start)
    //{
    //    var height = GetHeightValToNode(current, start);
    //    var width = GetWidthValToNode(current, start);


    //    throw new NotImplementedException();
    //}

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        var height = GetHeightValToNode(start, goal);
        var width = GetWidthValToNode(start, goal);

        SetStartingFCost(start, goal, height, width);

        var pathList = new List<Node>();
        FindPath(start, goal, pathList);

        return pathList;
    }

    private static int GetWidthValToNode(Node firstNode, Node secondNode)
    {
        return Math.Abs(firstNode.Column - secondNode.Column);
    }

    private static int GetHeightValToNode(Node firstNode, Node secondNode)
    {
        return Math.Abs(firstNode.Row - secondNode.Row);
    }

    private void FindPath(Node start, Node goal, List<Node> pathList)
    {
        var startRow = start.Row - 1 >= 0 ? start.Row - 1 : start.Row;
        var endRow = start.Row + 1 < this.Map.GetLength(0) ? start.Row + 1 : start.Row;

        var startColumn = start.Column - 1 >= 0 ? start.Column - 1 : start.Column;
        var endColumn = start.Column + 1 < this.Map.GetLength(1) ? start.Column + 1 : start.Column;

        for (int row = startRow; row < endRow; row++)
        {
            for (int column = startColumn; column < endColumn; column++)
            {
                var mapCell = this.Map[row, column];
                var currentCellNode = this.NodeMap[row, column];

                if (currentCellNode == null && mapCell != '*' && mapCell != 'P' && mapCell != 'W')
                {
                    currentCellNode = new Node(row, column);
                    currentCellNode.Fcost = GetFcost(currentCellNode, start, goal);
                    //var newFcost =    //Calculate new FCost
                    //if (currentCell.Fcost < newFcost)
                    //{
                    //    currentCell.Fcost = 14;////;
                    //}

                    //priorityQueue.Enqueue(currentCell); 
                }
                else if(currentCellNode != null && GetFcost(currentCellNode, start, goal) < currentCellNode.Fcost)
                {
                    currentCellNode.Fcost = GetFcost(currentCellNode, start, goal);
                }
            }
        }
        //CalculateFcostForNearbyCells(startRow, endRow, startColumn, endColumn, start, goal, this.Map);

    }

    private int GetFcost(Node currentCell, Node start, Node goal)
    {
        return AStar.GetH(currentCell, goal) + AStar.GetG(currentCell, start);
    }

    private void SetStartingFCost(Node start, Node goal, int height = 0, int width = 0)
    {
        var result = CalculateFCosts(height, width);

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