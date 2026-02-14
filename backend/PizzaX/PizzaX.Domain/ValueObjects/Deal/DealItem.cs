using PizzaX.Domain.Common;
using PizzaX.Domain.Entities;

namespace PizzaX.Domain.ValueObjects.Deal
{
    public sealed class DealItem
    {
        // Attributes
        //public Guid ProductId { get; }
        public string Name { get; }
        public Quantity Quantity { get; }

        // Navigation
        //public Product Product { get; }
        //public Pizza Pizza { get; }

        // Constructors
        private DealItem() { }
        private DealItem(Guid productId, string name, int quantity)
        {
            name = Function.Simplify(name)!;
            Guard.AgainstInvalidRegexPattern(RegexPattern.ProductName, name, nameof(Name));

            //ProductId = productId;
            Name = name;
            Quantity = Quantity.Create(quantity);
        }

        public static DealItem Create(Guid productId, string name, int quantity)
            => new(productId, name, quantity);
    }
}
