using PizzaX.Domain.Enums.Product;

namespace PizzaX.Application.DTOs.ProductDTOs
{
    public sealed class CreateProductDto
    {
        public byte[]? Image { get; init; }
        public decimal Price { get; init; }
        public string? Description { get; init; }
        public StockStatus StockStatus { get; init; }
        public ProductType ProductType { get; init; }
    }
}
