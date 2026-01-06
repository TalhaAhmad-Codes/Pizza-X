using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.Enums.Pizza;
using PizzaX.Domain.ValueObjects.Pizza;

namespace PizzaX.Domain.Entities
{
    public sealed class Product : AuditableEntity
    {
        // Attributes
        public byte[]? Image { get; private set; }
        public Price UnitPrice { get; private set; }
        public int Amount { get; private set; }
        public Status Status
            => (Amount > 0) ? Status.InStock : Status.OutOfStock;

        // Constructors
        protected Product() { }

        protected Product(byte[]? image, Price unitPrice, int amount)
        {
            Image = image;
            UnitPrice = unitPrice;
            Amount = amount;
        }
    }
}
