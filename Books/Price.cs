using System;
using System.Globalization;

namespace Books
{
    public class Price: IComparable<Price>
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

        public int CompareTo(Price other)
        {
            int result;
            if (Value > other.Value)
            {
                result = 1;
            }
            else if (Value < other.Value)
            {
                result = -1;
            }
            else
            {
                if (Culture != null && other.Culture != null)
                {
                    result = string.CompareOrdinal(Culture.Name, other.Culture.Name);
                }
                else
                {
                    if (Culture != null && other.Culture == null)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = -1;
                    }
                }
                
            }
            return result;
        }

        public override string ToString()
        {
            return Value.ToString(Culture) + (Culture != null ? Culture.NumberFormat.CurrencySymbol : "");
        }
    }
}