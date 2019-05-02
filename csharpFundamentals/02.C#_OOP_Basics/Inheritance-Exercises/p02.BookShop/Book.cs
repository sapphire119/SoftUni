using System;
using System.Text;

public class Book
{
    private const int MinTitleLenght = 3;
    private const int MinPrice = 0;

    private const string AuthorLastNameError = "Author not valid!";
    private const string TitleError = "Title not valid!";
    private const string PriceError = "Price not valid!";

    private string author;
    private string title;
    private decimal price;

    public Book() { }

    public Book(string author, string title, decimal price)
        : this()
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Author
    {
        get
        {
            return this.author;
        }
        set
        {
            var authorNames = value.Split();
            if (authorNames.Length == 2 && char.IsDigit(authorNames[1][0]))
            {
                throw new ArgumentException(AuthorLastNameError);
            }
            this.author = value;
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
            if (value.Length < MinTitleLenght)
            {
                throw new ArgumentException(TitleError);
            }
            this.title = value;
        }
    }

    public virtual decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < MinPrice)
            {
                throw new ArgumentException(PriceError);
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:F2}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}