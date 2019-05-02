using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SequenceOfCommands_broken
{
    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine().Split().Select(long.Parse).ToArray();

        string command = string.Empty;
        string commandToEnter = string.Empty;
        var iterator = 0;
        while (!command.Equals("stop"))
        {
            if (iterator != 0)
            {
                commandToEnter = command.Split().First();
                int[] args = new int[2];
                if (commandToEnter == "lshift")
                {
                    array = ArrayShiftLeft(array);
                }
                else if (commandToEnter == "rshift")
                {
                    array = ArrayShiftRight(array);
                }
                else if (commandToEnter == "add" ||
                    commandToEnter == "multiply" ||
                    commandToEnter == "subtract")
                {
                    string[] stringParams = command.Split();
                    args[0] = int.Parse(stringParams[1]);
                    args[1] = int.Parse(stringParams[2]);

                    array = PerformAction(array, stringParams[0], args);
                }
                PrintArray(array); 
            }
            iterator++;
            command = Console.ReadLine().Trim();

        }
    }

    static long[] PerformAction(long[] oldArray, string action, int[] args)
    {
        long[] clonedArray = oldArray.Clone() as long[];
        int pos = args[0] - 1;
        int value = args[1];

        switch (action)
        {
            case "multiply":
                clonedArray[pos] *= value;
                break;
            case "add":
                clonedArray[pos] += value;
                break;
            case "subtract":
                clonedArray[pos] -= value;
                break;
        }
        return clonedArray;

    }

    private static long[] ArrayShiftRight(long[] array)
    {
        var lastCharacter = array[array.Length - 1];
        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }
        array[0] = lastCharacter;
        return array;
    }

    private static long[] ArrayShiftLeft(long[] array)
    {
        var firstCharacter = array[0];

        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        array[array.Length-1] = firstCharacter;
        return array;
    }

    private static void PrintArray(long[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
