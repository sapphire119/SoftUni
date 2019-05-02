//using System.Linq;
using System.Collections.Generic;

public class Swapper : ISwapper
{
    public void Swap<T>(List<T> list, int[] indexes)
    {
        var firstIndex = indexes[0];
        var secondIndex = indexes[1];

        bool isFirstIndexInsideList = (0 <= firstIndex && firstIndex < list.Count);

        bool isSecondIndexInsideList = (0 <= secondIndex && secondIndex < list.Count);

        if (!isFirstIndexInsideList || !isSecondIndexInsideList)
        {
            return;
        }

        var median = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = median;
    }
}