using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint06
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        public Book(string title, string author, int pageCount)
        {
            Title = title;
            Author = author;
            PageCount = pageCount;
        }
    }

    public class Library
    {
        public IEnumerable<Book> Books { get; }
        public Predicate<Book> Filter { get; set; }
        public Library(IEnumerable<Book> books)
        {
            this.Books = books;
            Filter = book => true;
        }

        public IEnumerator<Book> GetEnumerator() =>
            new MyEnumerator(Books, Filter);
    }

    public sealed class MyEnumerator : IEnumerator<Book>
    {
        List<Book> books;

        int position = -1;

        public MyEnumerator(IEnumerable<Book> books, Predicate<Book> filter)
        {
            this.books = books.ToList().FindAll(filter);
        }

        public Book Current { get => books.ElementAt(position); }
        object IEnumerator.Current => Current;
        public bool MoveNext()
        {
            if (position < books.Count() - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset() => position = -1;

        public void Dispose() { }
    }

    public class MyUtils
    {
        public static List<Book> GetFiltered(IEnumerable<Book> books, Predicate<Book> filter)
        {
            List<Book> listOfBooks = new List<Book>();

            Library lib = new Library(books);
            lib.Filter = filter;

            foreach (var book in lib)
                listOfBooks.Add(book);

            return listOfBooks;
        }
    }
}
