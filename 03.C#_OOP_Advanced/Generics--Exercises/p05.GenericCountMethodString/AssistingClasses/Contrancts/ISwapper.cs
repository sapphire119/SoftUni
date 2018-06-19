using System.Collections.Generic;

public interface ISwapper
{
    void Swap<T>(List<T> list, int[] indexes);
}