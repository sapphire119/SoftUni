namespace p01.Intro
{
    using System;
    //using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);
            Book bookFour = new Book("Buy me", 2007, "Someone");


            var test = new List<Book> { bookOne, bookTwo, bookThree, bookFour };
            Console.WriteLine();

            //Library libraryOne = new Library();
            //Library libraryTwo = new Library(bookOne, bookTwo, bookThree, bookFour);

            //var books = new List<Book>() { bookOne, bookTwo, bookThree, bookFour };
            //books.Sort();
            //books.Sort(new BookComparator());

            //foreach (var book in libraryTwo)
            //{
            //    Console.WriteLine(book);
            //}

            var test132 = new Test();

            test132.Consumer();
        }

        
    }
}
