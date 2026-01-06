using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Pizza
{
    public sealed class Price
    {
        // Attributes
        public decimal Value { get; }

        // Constructor
        private Price(decimal price)
        {
            // Guard invalid data
            Guard.AgainstNegativeValue(price, nameof(Price));

            // Assigning value
            Value = price;
        }

        // Method - Create a new object
        public static Price Create(decimal price)
            => new(price);

        // Methods - Manipulate values
        public static Price operator +(Price a, Price b)
            => new(a.Value + b.Value);

        public static Price operator -(Price a, Price b)
            => new(a.Value - b.Value);

        // Methods - Comparision operators
        public static bool operator ==(Price a, Price b)
            => a.Value == b.Value;

        public static bool operator !=(Price a, Price b)
            => a.Value != b.Value;

        public static bool operator <(Price a, Price b)
            => a.Value < b.Value;

        public static bool operator >(Price a, Price b)
            => a.Value > b.Value;

        public static bool operator <=(Price a, Price b)
            => a.Value <= b.Value;

        public static bool operator >=(Price a, Price b)
            => a.Value >= b.Value;

        // Method - Override string
        public override string ToString()
            => $"{Value}";
    }
}
