using System;
using System.Collections;
using System.Collections.Generic;

namespace Books
{
    public class BookList
    {
        
        public readonly List<Book> Books = new List<Book>();

        public void Add(Book book)
        {
            Books.Add(book);
        }
        
        public void Remove(Book book)
        {
            Books.Remove(book);
        }

        public void SortByBook()
        {
            Books.Sort();
        }
        
        public void SortByIsbn()
        {
            Books.Sort(Book.CompareByIsbn);
        }
        
        public void SortByTitle()
        {
            Books.Sort(Book.CompareByTitle);
        }
        
        public void SortByAuthor()
        {
            Books.Sort(Book.CompareByTitle);
        }
        
        public void SortByPublisher()
        {
            Books.Sort(Book.CompareByPublisher);
        }
        
        public void SortByDate()
        {
            Books.Sort(Book.CompareByDate);
        }
        
        public void SortByPrice()
        {
            Books.Sort(Book.CompareByPrice);
        }
    }
}