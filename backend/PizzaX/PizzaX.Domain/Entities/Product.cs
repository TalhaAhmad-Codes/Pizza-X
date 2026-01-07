using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.Enums.Pizza;
using PizzaX.Domain.ValueObjects.Pizza;
using PizzaX.Domain.ValueObjects.Product;

namespace PizzaX.Domain.Entities
{
    public abstract class Product : AuditableEntity
    {
        // Attributes
        public byte[]? Image { get; protected set; }
        public Price Price { get; protected set; }
        public Quantity Quantity { get; protected set; }
        public string? Description { get; protected set; }
        public Status Status
            => (Quantity.Value > 0) ? Status.InStock : Status.OutOfStock;
        public decimal TotalPrice => Price.TotalPrice(Quantity);

        // Constructors
        protected Product() { }

        protected Product(byte[]? image, decimal unitPrice, int quantity, string? description)
        {
            Guard.AgainstWhitespace(description, nameof(Description));

            Image = image;
            Price = Price.Create(unitPrice);
            Quantity = Quantity.Create(quantity);
            Description = description;
        }

        /***********************************************/
        /* Methods to change properties of the product */
        /***********************************************/

        // Increment quantity by a number
        public void IncrementQuantity(int quantity = 1)
        {
            Guard.AgainstZeroOrLess(quantity, nameof(Quantity));

            Quantity = Quantity.Create(Quantity.Value + quantity);

            MarkUpdated();
        }

        // Decrement quantity by a number
        public void DecrementQuantity(int quantity = 1)
        {
            Guard.AgainstZeroOrLess(quantity, nameof(Quantity));

            Quantity = Quantity.Create(Quantity.Value - quantity);

            MarkUpdated();
        }

        // Update price of the product
        public void UpdatePrice(decimal unitPrice)
        {
            Price = Price.Create(unitPrice);

            MarkUpdated();
        }

        // Update image of the product
        public void UpdateImage(byte[]? image)
        {
            Image = image;

            MarkUpdated();
        }

        // Update description of the product
        public void UpdateDescription(string? description)
        {
            Guard.AgainstWhitespace(description, nameof(Description));

            Description = description;

            MarkUpdated();
        }
    }
}
