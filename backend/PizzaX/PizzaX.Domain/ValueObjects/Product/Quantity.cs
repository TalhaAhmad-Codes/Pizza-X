using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Product
{
    public sealed class Quantity
    {
        // Attribute
        public int Value { get; }

        // Constructors
        private Quantity() { }
        private Quantity(int value)
        {
            Guard.AgainstNegativeValue(value, nameof(Value));

            Value = value;
        }

        // Method - Create a new object
        public static Quantity Create(int value)
            => new(value);

        // Method - Convert to string
        public override string ToString()
            => $"{Value}";
    }
}
