using PizzaX.Application.DTOs.Common;
using PizzaX.Domain.Enums.Product;

namespace PizzaX.Application.DTOs.ProductDTOs
{
    public abstract class BaseProductDto : BaseAuditableDto
    {
        // Data fields
        public byte[]? Image { get; init; }
        public decimal UnitPrice { get; init; }
        public decimal TotalPrice { get; init; }
        public int Quantity { get; init; }
        public ProductStockStatus StockStatus { get; init; }
        public string? Description { get; init; }
    }
}
