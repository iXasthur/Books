using System;

namespace Books
{

    public class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime? Date { get; set; }
        public Price Price { get; set; }

        public Book(string isbn, string title, string author, string publisher, DateTime date, Price price)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            Publisher = publisher;
            Date = date;
            Price = price;
        }

        // public bool Equals(Book other)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public int CompareTo(Book other)
        // {
        //     throw new NotImplementedException();
        // }
    }
}