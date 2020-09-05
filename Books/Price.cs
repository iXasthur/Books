using System;
using System.Globalization;

namespace Books
{
    public class Price
    {
        public CultureInfo Culture { get; set; }
        public double Value { get; set; }

        public Price(CultureInfo culture, double value)
        {
            Culture = culture;
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString(Culture) + Culture.NumberFormat.CurrencySymbol;
        }
    }
}