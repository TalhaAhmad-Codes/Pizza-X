using PizzaX.Domain.Enums.Product;

namespace PizzaX.Application.DTOs.ProductDTOs.Common
{
    public sealed class BaseCreateProductDto
    {
        public byte[]? Image { get; init; }
        public decimal Price { get; init; }
        public string? Description { get; init; }
        public StockStatus StockStatus { get; init; }
    }
}
