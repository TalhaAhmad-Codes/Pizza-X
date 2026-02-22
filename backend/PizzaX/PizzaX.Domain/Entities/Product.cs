using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.Enums.Product;
using PizzaX.Domain.ValueObjects.Product;

namespace PizzaX.Domain.Entities
{
    public sealed class Product : AuditableEntity
    {
        // Attributes
        public byte[]? Image { get; private set; }
        public Price Price { get; private set; }
        public string? Description { get; private set; }
        public StockStatus StockStatus { get; private set; }
        public ProductType ProductType { get; private set; }

        // Navigation

        // Constructors
        private Product() { }

        private Product(byte[]? image, decimal price, string? description, StockStatus stockStatus, ProductType productType)
        {
            Guard.AgainstWhitespace(description, nameof(Description));

            Image = image;
            Price = Price.Create(price);
            StockStatus = stockStatus;
            Description = Function.Simplify(description);
            ProductType = productType;
        }

        public static Product Create(byte[]? image, decimal price, string? description, StockStatus stockStatus, ProductType productType)
            => new(image, price, description, stockStatus, productType);

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
