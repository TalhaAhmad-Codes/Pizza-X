using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.Enums.Product;
using PizzaX.Domain.ValueObjects.Product;

namespace PizzaX.Domain.Entities
{
    public sealed class Product : AuditableEntity
    {
        // Attributes
        public byte[]? Image { get; protected set; }
        public Price Price { get; protected set; }
        public string? Description { get; protected set; }
        public StockStatus StockStatus { get; protected set; }
        public ProductType ProductType { get; protected set; }

        // Navigation

        // Constructors
        protected Product() { }

        protected Product(byte[]? image, decimal unitPrice, string? description, StockStatus stockStatus, ProductType productType)
        {
            Guard.AgainstWhitespace(description, nameof(Description));

            Image = image;
            Price = Price.Create(unitPrice);
            StockStatus = stockStatus;
            Description = Function.Simplify(description);
            ProductType = productType;
        }

        /***********************************************/
        /* Methods to change properties of the product */
        /***********************************************/

        // Update stock status of the product
        public void UpdateStockStatus(StockStatus stockStatus)
        {
            StockStatus = stockStatus;

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

            Description = Function.Simplify(description);

            MarkUpdated();
        }
    }
}
