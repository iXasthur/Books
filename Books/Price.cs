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