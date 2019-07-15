using System;
using System.Linq;
using System.Collections.Generic;

public class AStar
{
    private const string StartSymbol = "P";
    private const string EndSymbol = "*";

    private const int NormalStep = 10;
    private const int DiagonalStep = 14;

    public Node[,] Map { get; private set; }

    public AStar(char[,] map)
    {
        this.Map = new Node[map.GetLength(0), map.GetLength(1)];
        SetMap(map);
    }

    private void SetMap(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == 'W')
                {
                    continue;
                }
                this.Map[i, j] = new Node(i, j);
            }
        }
    }

    public static int GetHCost(Node current, Node goal)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        int height = GetHeightValToNode(start, goal);
        int width = GetWidthValToNode(start, goal);

        SetStartingFCost(start, goal, height, width);

        //Collection
        var pathList = new List<Node>() { start };

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

        //priorityQueue.Enqueue(start);

        for (int row = startRow; row < endRow; row++)
        {
            for (int column = startColumn; column < endColumn; column++)
            {
                var currentCell = this.Map[row, column];
                if (currentCell != null)
                {
                    var newFcost = 0;//;
                    if (currentCell.Fcost < newFcost)
                    {
                        this.Map[row, column].Fcost = 14;////;
                    }

                    //priorityQueue.Enqueue(currentCell); 
                }
            }
        }
        //CalculateFcostForNearbyCells(startRow, endRow, startColumn, endColumn, start, goal, this.Map);

    }

    private void SetStartingFCost(Node start, Node goal, int height = 0, int width = 0, int result = 0)
    {
        result = CalculateFCosts(height, width, result);

        start.Fcost = result;
        goal.Fcost = result;

        this.Map[start.Row, start.Column] = start;
        this.Map[goal.Row, goal.Column] = goal;
    }

    private int CalculateFCosts(int height, int width, int result)
    {
        if (width > height)
        {
            result = CalculateHorizontalFcost(width, height);
        }
        else if (width < height)
        {
            result = CalculateVerticalFcost(width, height);
        }
        else
        {
            result = CalculateDiagonalFcost(width, height);
        }

        return result;
    }

    private int CalculateDiagonalFcost(int width, int height)
    {
        var diagonalFcost = height * DiagonalStep;

        return diagonalFcost;
        //start.Fcost = diagonalFcost;
        //goal.Fcost = diagonalFcost;
    }

    private int CalculateVerticalFcost(int width, int height)
    {
        var verticalSteps = height - width;

        var diagStepsFcost = width * DiagonalStep;
        var verticalStepsFcost = verticalSteps * NormalStep;

        var result = verticalStepsFcost + diagStepsFcost;

        return result;
        //start.Fcost = verticalStepsFcost + diagStepsFcost;
        //goal.Fcost = verticalStepsFcost + diagStepsFcost;
    }

    private int CalculateHorizontalFcost(int width, int height)
    {
        var horizontalStep = width - height;

        var diagStepsFcost = height * DiagonalStep;
        var horizontalStepsFcost = horizontalStep * NormalStep;

        var result = horizontalStepsFcost + diagStepsFcost;

        return result;
        //start.Fcost = horizontalStepsFcost + diagStepsFcost;
        //goal.Fcost = horizontalStepsFcost + diagStepsFcost;
    }
}