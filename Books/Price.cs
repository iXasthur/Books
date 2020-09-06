using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Books
{
    public class Price: IComparable<Price>
    {
        
        // Isn't serialized
        public CultureInfo Culture;
        public double Value { get; set; }

        // For serialization
        public string CultureName
        {
            get => Culture.Name;
            set => Culture = new CultureInfo(value);
        }

        public Price(CultureInfo culture, double value)
        {
            Culture = culture;
            Value = value;
        }
        
        public Price()
        {
            Culture = null;
            Value = 0;
        }

        public int CompareTo(Price other)
        {
            int result = Price.CompareByValue(this, other);
            if (result == 0)
            {
                result = Price.CompareByCulture(this, other);
            }
            return result;
        }

        public override string ToString()
        {
            return Value.ToString(new CultureInfo("fr")) + (Culture != null ? " " + Culture.NumberFormat.CurrencySymbol : "");
        }

        static int CompareByValue(Price price0, Price price1)
        {
            if (price0.Value > price1.Value)
            {
                return 1;
            }
            else if (price0.Value < price1.Value)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        static int CompareByCulture(Price price0, Price price1)
        {
            if (price0.Culture != null && price1.Culture != null)
            {
                return string.CompareOrdinal(price0.Culture.Name, price1.Culture.Name);
            }
            else if (price0.Culture != null && price1.Culture == null)
            {
                return 1;
            } else
            {
                return -1;
            }
        }
        
    }
}