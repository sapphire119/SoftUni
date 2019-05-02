using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class Library : IEnumerable<Book>
{
    private SortedSet<Book> books;
    private BookComparator comparator;

    public Library(params Book[] books)
    {
        this.comparator = new BookComparator();
        this.Books = new SortedSet<Book>(books, comparator);
    }

    public SortedSet<Book> Books
    {
        get
        {
            return this.books;
        }
        set
        {
            this.books = value;
        }
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }


    private class LibraryIterator : IEnumerator<Book>
    {
        private IReadOnlyList<Book> books;
        private int currentIndex;

        public LibraryIterator(ISet<Book> books)
        {
            this.books = books.ToList();
            this.currentIndex = -1;
        }

        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < this.books?.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}