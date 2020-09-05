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
        
    }
}