﻿using System;
using System.Linq;
using System.Collections.Generic;

public class Book //: IComparable<Book>
{
    private string title;
    private int year;

    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = authors.ToList();
    }

    public IReadOnlyList<string> Authors { get; set; }

    public int Year
    {
        get
        {
            return this.year;
        }
        set
        {
            this.year = value;
        }
    }

    public string Title
    {
        get
        {
            return this.title;
        }
        set
        {
            this.title = value;
        }
    }

    public int CompareTo(Book otherBook)
    {
        var result = this.Year.CompareTo(otherBook.Year);
        if (result == 0)
        {
            result = this.Title.CompareTo(otherBook.Title);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}