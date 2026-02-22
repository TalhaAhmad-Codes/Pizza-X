using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Deal
{
    public sealed class Quantity
    {
        // Attribute
        public int Value { get; }

        // Constructors
        private Quantity() { }
        private Quantity(int value)
        {
            Guard.AgainstZeroOrLess(value, nameof(Value));

            Value = value;
        }

        // Method - Create a new object
        public static Quantity Create(int value)
            => new(value);

        // Methods - Comparision operators
        public static bool operator >=(Quantity quantity, int other)
            => quantity.Value >= other;

        public static bool operator <=(Quantity quantity, int other)
            => quantity.Value <= other;

        public static bool operator ==(Quantity quantity, int other)
            => quantity.Value == other;

        public static bool operator !=(Quantity quantity, int other)
            => quantity.Value != other;

        // Method - Convert to string
        public override string ToString()
            => $"{Value}";
    }
}
