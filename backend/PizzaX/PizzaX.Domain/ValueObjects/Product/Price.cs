using PizzaX.Domain.Common;
using PizzaX.Domain.ValueObjects.Deal;

namespace PizzaX.Domain.ValueObjects.Product
{
    public sealed class Price
    {
        // Attributes
        public decimal UnitPrice { get; }
        public static decimal TotalPrice(decimal price, Quantity quantity)
            => price * quantity.Value;

        // Constructors
        private Price() { }
        private Price(decimal unitPrice)
        {
            // Guard invalid data
            Guard.AgainstZeroOrLess(unitPrice, nameof(Price));

            // Assigning value
            UnitPrice = unitPrice;
        }

        // Method - Create a new object
        public static Price Create(decimal unitPrice)
            => new(unitPrice);

        // Method - Comparision operators
        public static bool operator >=(Price price, decimal other)
            => price.UnitPrice >= other;

        public static bool operator <=(Price price, decimal other)
            => price.UnitPrice <= other;

        // Method - Override string
        public override string ToString()
            => $"{UnitPrice}";
    }
}
