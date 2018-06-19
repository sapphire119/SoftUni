using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        var result = x.Title.CompareTo(y.Title);
        if (result == 0)
        {
            var bookYearComparer = x.Year.CompareTo(y.Year);

            if (bookYearComparer > 0) result = -1;
            else if (bookYearComparer < 0) result = 1;
            else result = 0;

        }

        return result;
    }
}