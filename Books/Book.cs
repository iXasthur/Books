using System;

namespace Books
{

    public class Book: IEquatable<Book>, IComparable<Book>
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
            int result = string.CompareOrdinal(Isbn, other.Isbn);
            if (result == 0)
            {
                result = string.CompareOrdinal(Title, other.Title);
                if (result == 0)
                {
                    result = string.CompareOrdinal(Author, other.Author);
                    if (result == 0)
                    {
                        result = string.CompareOrdinal(Publisher, other.Publisher);
                        if (result == 0)
                        {
                            if (Date == null && other.Date != null)
                            {
                                result = -1;
                            }
                            else if (Date != null && other.Date == null)
                            {
                                result = 1;
                            }
                            else
                            {
                                if (Date == other.Date)
                                {
                                    result = Price.CompareTo(other.Price);
                                }
                                else
                                {
                                    if (Date != null && other.Date == null)
                                    {
                                        result = 1;
                                    }
                                    else
                                    {
                                        result = -1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}