using PizzaX.Domain.Common;
using PizzaX.Domain.ValueObjects.Product;

namespace PizzaX.Domain.ValueObjects.Pizza
{
    public sealed class Price
    {
        // Attributes
        public decimal UnitPrice { get; }
        public decimal TotalPrice(Quantity quantity)
            => UnitPrice * quantity.Value;

        // Constructor
        private Price(decimal unitPrice)
        {
            // Guard invalid data
            Guard.AgainstNegativeValue(unitPrice, nameof(Price));

            // Assigning value
            UnitPrice = unitPrice;
        }

        // Method - Create a new object
        public static Price Create(decimal unitPrice)
            => new(unitPrice);

        // Method - Override string
        public override string ToString()
            => $"{UnitPrice}";
    }
}
