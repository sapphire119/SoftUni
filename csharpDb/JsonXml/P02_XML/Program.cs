using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace P02_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //One(); //Обработване на XML
            //Two(); //Обработване на XML
            Three(); //Създавване на XML
            //Rest services -- приемат Параметри и връщат Json-и

            //XML - EXtensible Markup Languge
            //XML e meta език (Мета език е такъв език, който описва дргуи езици (Някакъв начин да опишем някакви данни във сериализиран вид.))

            //<?xml version="1.0" (encoding="UTF-8")?>  <----------------------- Header tag (Prolog)
            //Root element <library...
            //<library name="Developer's Library"> <-- Attribtes 
            //(Атрибути (key/value pair name="..."))
            //  <book>
            //    <title>Professional C# 4.0 and .NET 4</title>
            //    <author>Christian Nagel</author>
            //    <isbn>978-0-470-50225-9</isbn>
            //  </book>
            //  <book>
            //    <title>Teach Yourself XML in 10 Minutes</title>
            //    <author>Andrew H. Watt</author>
            //    <isbn>978-0-672-32471-0</isbn>
            //  </book>
            //</library>
        }

        private static void Three()
        {
            var doc = new XDocument();

            var books = new XElement("books");

            doc.Add(books);

            var bookTitle = new XElement("title", "C# Programming");
            var bookDescription = new XElement("description", "This book will fullfill your wildest dreams!");

            var book = new XElement("book",
                    bookTitle,
                    bookDescription);

            books.Add(book);

            doc.Save("seriliaziedLibrary.xml");

            Console.WriteLine(doc.ToString());
        }

        private static void Two()
        {
            var xmlString = File.ReadAllText("xml.xml");

            var xml = XDocument.Parse(xmlString);

            var elements = xml.Root.Elements();

            var data = elements.Select(e => new
            {
                Title = e.Element("title").Value,
                Author = e.Element("author").Value,
                ISBN = e.Element("isbn")?.Value ?? "No ISBN Code!"
            })
            .ToArray();

            Console.WriteLine();
        }

        private static void One()
        {
            var xmlString = File.ReadAllText("xml.xml");

            var xml = XDocument.Parse(xmlString);

            var root = xml.Root.Elements();

            foreach (var xElement in root)
            {
                //Това е Case sensitive
                var title = xElement.Element("title");

                title.SetAttributeValue("otherTitle", "Learn C#");
                var otherTitle = title.Attribute("otherTitle").Value;

                var attributes = xElement.Attributes().ToArray();

                var author = xElement.Element("author");
                var isbn = xElement.Element("isbn")?.Value ?? "no isbn"; //<-- null coalesing оператор Това казва ако xElement.Element("isbn") e null ми изпринтирай "no isbn" (ако нямаше ?? "no isbn" щеше да върне за isbn -- null), а пък ако имаше стойност да ми върне стойността.
                author.Remove();

                xElement.SetElementValue("random", 1234);
                var random = xElement.Element("random").Value;

                Console.WriteLine($"{title} - {author} " + Environment.NewLine +
                    $"-- with ISBN: {isbn}");
            }

        }
    }
}
