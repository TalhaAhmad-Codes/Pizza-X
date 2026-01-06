using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Product
{
    public sealed class Amount
    {
        // Attribute
        public int Value { get; }

        // Constructor
        private Amount(int value)
        {
            Guard.AgainstNegativeValue(value, nameof(Value));

            Value = value;
        }

        // Method - Create a new object
        public static Amount Create(int value)
            => new(value);

        // Methods - Manipulate the values
        public static Amount operator +(Amount a, Amount b)
            => new(a.Value + b.Value);

        public static Amount operator -(Amount a, Amount b)
            => new(a.Value - b.Value);

        // Methods - Compare the values
        public static bool operator ==(Amount a, Amount b)
            => a.Value == b.Value;

        public static bool operator !=(Amount a, Amount b)
            => !(a == b);

        public static bool operator <(Amount a, Amount b)
            => a.Value < b.Value;

        public static bool operator >(Amount a, Amount b)
            => a.Value > b.Value;

        public static bool operator <=(Amount a, Amount b)
            => a.Value < b.Value;

        public static bool operator >=(Amount a, Amount b)
            => a.Value > b.Value;

        // Method - Convert to string
        public override string ToString()
            => $"{Value}";
    }
}
