using System;
using System.Linq;
using System.Collections.Generic;

public class Engine
{
    private readonly Writer writer;
    private readonly Reader reader;
    private CustomList<string> customList;

    public Engine()
    {
        this.writer = new Writer();
        this.reader = new Reader();
        
        this.customList = new CustomList<string>();
    }

    public void Run()
    {
        string command;
        while ((command = reader.ReadLine()) != "END")
        {
            var commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var currentCommand = commandArgs[0];

            switch (currentCommand)
            {
                case "Add": AddElementToList(commandArgs.Skip(1).ToArray()); break;
                case "Remove": RemoveElement(commandArgs.Skip(1).ToArray()); break;
                case "Contains": DoesListContainElement(commandArgs.Skip(1).ToArray()); break;
                case "Swap": SwapElementInList(commandArgs.Skip(1).ToArray()); break;
                case "Greater": FindElementsGreaterThan(commandArgs.Skip(1).ToArray()); break;
                case "Max": writer.WriteLine(this.customList.Max()); break;
                case "Min": writer.WriteLine(this.customList.Min()); break;
                case "Sort": this.customList = SortedClass.Sort(this.customList); break;
                case "Print": PrintAllEmenets(); break;
            }
        }
    }

    private void PrintAllEmenets()
    {
        foreach (var item in this.customList)
        {
            writer.WriteLine(item);
        }
    }

    private void FindElementsGreaterThan(string[] restOfArgs)
    {
        var element = restOfArgs[0];

        writer.WriteLine(this.customList.CountGreaterThan(element));
    }

    private void SwapElementInList(string[] restOfArgs)
    {
        var firstIndex = int.Parse(restOfArgs[0]);
        var secondIndex = int.Parse(restOfArgs[1]);

        this.customList.Swap(firstIndex, secondIndex);
    }

    private void DoesListContainElement(string[] restOfArgs)
    {
        var elementToLookFor = restOfArgs[0];

        writer.WriteLine(this.customList.Contains(elementToLookFor));
    }

    private void RemoveElement(string[] restOfInputArgs)
    {
        var indexOfElementToRemove = int.Parse(restOfInputArgs[0]);

        //this.customList.Remove(indexOfElementToRemove);
        this.customList.Remove(indexOfElementToRemove);
        //writer.WriteLine(this.customList.Remove(indexOfElementToRemove));
    }

    private void AddElementToList(string[] restOfInputArgs)
    {
        var elementToAdd = restOfInputArgs[0];

        this.customList.Add(elementToAdd);
    }
}