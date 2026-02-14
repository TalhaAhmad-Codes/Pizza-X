using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.Enums.BaseProduct;
using PizzaX.Domain.ValueObjects.BaseProduct;
using PizzaX.Domain.ValueObjects.Deal;

namespace PizzaX.Domain.Entities
{
    public abstract class BaseProduct : AuditableEntity
    {
        // Attributes
        public byte[]? Image { get; protected set; }
        public Price Price { get; protected set; }
        public string? Description { get; protected set; }
        public ProductStockStatus StockStatus { get; protected set; }
        
        // Navigation
        //public DealItem DealItem { get; protected set; }

        // Constructors
        protected BaseProduct() { }

        protected BaseProduct(byte[]? image, decimal unitPrice, string? description, ProductStockStatus stockStatus)
        {
            Guard.AgainstWhitespace(description, nameof(Description));

            Image = image;
            Price = Price.Create(unitPrice);
            StockStatus = stockStatus;
            Description = Function.Simplify(description);
        }

        /***********************************************/
        /* Methods to change properties of the product */
        /***********************************************/

        // Update stock status of the product
        public void UpdateStockStatus(ProductStockStatus stockStatus)
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
