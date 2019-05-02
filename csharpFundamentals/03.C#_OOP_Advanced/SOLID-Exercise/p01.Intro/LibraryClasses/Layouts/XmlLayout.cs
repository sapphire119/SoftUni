using System;
using System.Text;
using System.Xml.Linq;

public class XmlLayout : ILayout
{
    private Validator validator;

    public XmlLayout()
    {
        this.validator = new Validator();
    }

    public string Format(string[] arguments)
    {
        this.validator.ValidateLayout(arguments);

        var date = arguments[0];
        var typeMessage = arguments[1];
        var endMessage = arguments[2];

        //var doc = new XDocument();


        var log = new XElement("log");

        var xDate = new XElement("date", date);
        var xType = new XElement("level", typeMessage);
        var message = new XElement("message", endMessage);

        log.Add(xDate, xType, message);

        return log.ToString();

        //var books = new XElement("books");

        //doc.Add(books);

        //var bookTitle = new XElement("title", "C# Programming");
        //var bookDescription = new XElement("description", "This book will fullfill your wildest dreams!");

        //var book = new XElement("book",
        //        bookTitle,
        //        bookDescription);

        //books.Add(book);

        //doc.Save("seriliaziedLibrary.xml");

        //Console.WriteLine(doc.ToString());

    }
}