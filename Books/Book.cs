using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Books
{
    
    public class Book: IEquatable<Book>, IComparable<Book>
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int PagesAmount { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime? Date { get; set; }
        public Price Price { get; set; }

        public Book(string isbn, string title, int pagesAmount, string author, string publisher, DateTime date, Price price)
        {
            Isbn = isbn;
            Title = title;
            PagesAmount = pagesAmount;
            Author = author;
            Publisher = publisher;
            Date = date;
            Price = price;
        }
        
        public Book()
        {
            Isbn = "0-000-000000";
            Title = "NEW BOOK";
            PagesAmount = 0;
            Author = "AUTHOR";
            Publisher = "PUBLISHER";
            Date = new DateTime(1970,1,1);
            Price = new Price(new CultureInfo("en"), 0);
        }

        public bool Equals(Book other)
        {
            if (other == null)
            {
                return false;
            }

            return Isbn == other.Isbn &&
                   Title == other.Title &&
                   Author == other.Author &&
                   Publisher == other.Publisher &&
                   Date == other.Date &&
                   Price == other.Price;
        }
        
        public int CompareTo(Book other)
        {
            int result = Book.CompareByIsbn(this, other);
            if (result == 0)
            {
                result = Book.CompareByTitle(this, other);
                if (result == 0)
                {
                    result = Book.CompareByAuthor(this, other);
                    if (result == 0)
                    {
                        result = Book.CompareByPublisher(this, other);
                        if (result == 0)
                        {
                            result = Book.CompareByDate(this, other);
                            if (result == 0)
                            {
                                result = Book.CompareByPrice(this, other);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static int CompareByIsbn(Book book0, Book book1)
        {
            return string.CompareOrdinal(book0.Isbn, book1.Isbn);
        }
        
        public static int CompareByTitle(Book book0, Book book1)
        {
            return string.CompareOrdinal(book0.Title, book1.Title);
        }
        
        public static int CompareByAuthor(Book book0, Book book1)
        {
            return string.CompareOrdinal(book0.Author, book1.Author);
        }
        
        public static int CompareByPagesAmount(Book book0, Book book1)
        {
            if (book0.PagesAmount > book1.PagesAmount)
            {
                return 1;
            }
            else if (book0.PagesAmount < book1.PagesAmount)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        
        public static int CompareByPublisher(Book book0, Book book1)
        {
            return string.CompareOrdinal(book0.Publisher, book1.Publisher);
        }
        
        public static int CompareByDate(Book book0, Book book1)
        {
            int result;

            if (book0.Date != null && book1.Date == null)
            {
                result = 1;
            }
            else if (book0.Date == null && book1.Date != null)
            {
                result = -1;
            }
            else if (book0.Date == null && book1.Date == null)
            {
                result = 0;
            }
            else
            {
                DateTime date0 = book0.Date.GetValueOrDefault();
                DateTime date1 = book1.Date.GetValueOrDefault();
                result = DateTime.Compare(date0, date1);
            }
            
            return result;
        }
        
        public static int CompareByPrice(Book book0, Book book1)
        {
            return book0.Price.CompareTo(book1.Price);;
        }
    }
}