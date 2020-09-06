using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Xml.Serialization;

namespace Books
{
    public class BookStorage
    {
        
        public List<Book> Books { get; set; } = new List<Book>();

        public void Add(Book book)
        {
            Books.Add(book);
        }
        
        public void Remove(Book book)
        {
            Books.Remove(book);
        }

        public void Reset()
        {
            Books.Clear();
        }

        public string CreateJson()
        {
            return JsonSerializer.Serialize(this);
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
        
        public void SortByPages()
        {
            Books.Sort(Book.CompareByPagesAmount);
        }
        
        public void SortByAuthor()
        {
            Books.Sort(Book.CompareByAuthor);
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