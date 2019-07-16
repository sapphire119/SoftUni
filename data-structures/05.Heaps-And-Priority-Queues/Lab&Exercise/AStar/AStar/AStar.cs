﻿using System;
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

    public static int GetH(Node current, Node goal)
    {
        //var width = GetWidthValToNode(current, goal);
        //var height = GetHeightValToNode(current, goal);

        //return CalculateFCosts(height, width);

        return default(int);
    }

    public static int GetG(Node current, Node previousNode)
    {
        //if (current != previousNode)
        //{
        //    var width = GetWidthValToNode(current, previousNode);
        //    var height = GetHeightValToNode(current, previousNode);
        //    var test = CalculateFCosts(height, width);

        //    return test;
        //}


        //return current.Hcost;

        return default(int);
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        var height = GetHeightValToNode(start, goal);
        var width = GetWidthValToNode(start, goal);

        SetStartingFCost(start, goal, height, width);

        var priorityQueue = new PriorityQueue<Node>();
        FindPath(start, goal, priorityQueue);


        //var path = GetPathNodes(this.Map);
        //return path;
        return default(IEnumerable<Node>);
    }

    private void FindPath(Node start, Node goal, PriorityQueue<Node> priorityQueue /*Node nextNode*/ /*Node newNodeStart = default(Node), Node previousNode = default(Node)*/)
    {
        var startRow = start.Row - 1 >= 0 ? start.Row - 1 : start.Row;
        var endRow = start.Row + 1 < this.Map.GetLength(0) ? start.Row + 1 : start.Row;

        var startColumn = start.Column - 1 >= 0 ? start.Column - 1 : start.Column;
        var endColumn = start.Column + 1 < this.Map.GetLength(1) ? start.Column + 1 : start.Column;

        for (int row = startRow; row <= endRow; row++)
        {
            for (int column = startColumn; column <= endColumn; column++)
            {
                var mapCell = this.Map[row, column];
                var currentCellNode = this.NodeMap[row, column];

                if (currentCellNode == null && mapCell != '*' && mapCell != 'P' && mapCell != 'W')
                {
                    currentCellNode = new Node(row, column);

                    //currentCellNode.Fcost = GetFcost(currentCellNode, start, goal);
                    //currentCellNode.Hcost = GetH(currentCellNode, goal);

                    this.NodeMap[row, column] = currentCellNode;

                    priorityQueue.Enqueue(currentCellNode);
                }
                else if(currentCellNode != null  && GetFcost(currentCellNode, start, goal) < currentCellNode.Fcost)
                {
                    //currentCellNode.Fcost = GetFcost(currentCellNode, start, goal);
                    //currentCellNode.Hcost = GetH(currentCellNode, goal);

                    priorityQueue.DecreaseKey(currentCellNode);
                }
                else if (mapCell == '*')
                {
                    ////
                    return;
                }
            }
        }

        FindPath(start, goal, priorityQueue /* priorityQueue.Dequeue()*/);
        //CalculateFcostForNearbyCells(startRow, endRow, startColumn, endColumn, start, goal, this.Map);
    }

    //private void SetCosts(Node currentCellNode, Node previousNode, Node goal)
    //{
    //    currentCellNode.Gcost = GetG(currentCellNode, previousNode);
    //    currentCellNode.Hcost = GetH(currentCellNode, goal);

    //    currentCellNode.Fcost = currentCellNode.Gcost + currentCellNode.Hcost;
    //    //currentCellNode.Hcost = GetH(currentCellNode, goal);
    //}

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