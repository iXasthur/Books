using System;
using System.Globalization;

namespace Books.BookStorage.Economics
{
    public class Price : IComparable<Price>
    {
        // Isn't serialized
        public CultureInfo Culture;

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

        public double Value { get; set; }

        // For serialization
        public string CultureName
        {
            get => Culture.Name;
            set => Culture = new CultureInfo(value);
        }

        public int CompareTo(Price other)
        {
            var result = CompareByValue(this, other);
            if (result == 0) result = CompareByCulture(this, other);
            return result;
        }

        public override string ToString()
        {
            return Value.ToString(new CultureInfo("fr")) +
                   (Culture != null ? " " + Culture.NumberFormat.CurrencySymbol : "");
        }

        private static int CompareByValue(Price price0, Price price1)
        {
            if (price0.Value > price1.Value)
                return 1;
            if (price0.Value < price1.Value)
                return -1;
            return 0;
        }

        private static int CompareByCulture(Price price0, Price price1)
        {
            if (price0.Culture != null && price1.Culture != null)
                return string.CompareOrdinal(price0.Culture.Name, price1.Culture.Name);
            if (price0.Culture != null && price1.Culture == null)
                return 1;
            return -1;
        }
    }
}