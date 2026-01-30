using PizzaX.Domain.Enums.BaseProduct;
using PizzaX.Domain.Enums.Pizza;

namespace PizzaX.Domain.Entities
{
    public sealed class Pizza : BaseProduct
    {
        // Attributes
        public PizzaSize Size { get; private set; }
        public Guid VarietyId { get; private set; }

        // Navigation properties
        public PizzaVariety Variety { get; private set; }

        // Constructors
        private Pizza() : base() { }

        private Pizza(byte[]? image, decimal unitPrice, ProductStockStatus stockStatus, string? description, PizzaSize size, Guid varietyId)
            : base(image, unitPrice, description, stockStatus)
        {
            Size = size;
            VarietyId = varietyId;
        }

        // Method - Create a new object
        public static Pizza Create(byte[]? image, decimal unitPrice, string? description, PizzaSize size, Guid varietyId, ProductStockStatus stockStatus)
            => new(image, unitPrice, stockStatus, description, size, varietyId);
    }
}
