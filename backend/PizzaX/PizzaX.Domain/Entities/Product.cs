using PizzaX.Domain.Common;
using PizzaX.Domain.Enums.Pizza;
using PizzaX.Domain.ValueObjects.Pizza;
using PizzaX.Domain.ValueObjects.Product;

namespace PizzaX.Domain.Entities
{
    public abstract class Product
    {
        // Attributes
        public byte[]? Image { get; private set; }
        public Price Price { get; private set; }
        public Quantity Quantity { get; private set; }
        public string? Description { get; private set; }
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
        public virtual void IncrementQuantity(int quantity = 1)
        {
            Guard.AgainstZeroOrLess(quantity, nameof(Quantity));

            Quantity = Quantity.Create(Quantity.Value + quantity);
        }

        // Decrement quantity by a number
        public virtual void DecrementQuantity(int quantity = 1)
        {
            Guard.AgainstZeroOrLess(quantity, nameof(Quantity));

            Quantity = Quantity.Create(Quantity.Value - quantity);
        }

        // Update price of the product
        public virtual void UpdatePrice(decimal unitPrice)
        {
            Price = Price.Create(unitPrice);
        }

        // Update image of the product
        public virtual void UpdateImage(byte[]? image)
        {
            Image = image;
        }

        // Update description of the product
        public virtual void UpdateDescription(string? description)
        {
            Guard.AgainstWhitespace(description, nameof(Description));

            Description = description;
        }
    }
}
