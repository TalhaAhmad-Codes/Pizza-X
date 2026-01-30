using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Deal
{
    public sealed class DealItem
    {
        // Attributes
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public Quantity Quantity { get; private set; }

        // Constructors
        private DealItem() { }
        private DealItem(Guid productId, string name, int quantity)
        {
            name = Function.Simplify(name)!;
            Guard.AgainstInvalidRegexPattern(RegexPattern.ProductName, name, nameof(Name));

            ProductId = productId;
            Name = name;
            Quantity = Quantity.Create(quantity);
        }

        // Methods - Create a new object
        public static DealItem Create(Guid productId, string name, int quantity)
            => new(productId, name, quantity);

        // Method - Convert to string
        public override string ToString()
            => $"{Quantity} {Name}";
    }
}
