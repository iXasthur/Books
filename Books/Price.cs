using System;
using System.Globalization;

namespace Books
{
    public class Price
    {
#nullable enable
        public CultureInfo? Culture { get; set; }
#nullable disable
        public double Value { get; set; }

        public Price(CultureInfo culture, double value)
        {
            Culture = culture;
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString(Culture) + (Culture != null ? Culture.NumberFormat.CurrencySymbol : "");
        }
    }
}