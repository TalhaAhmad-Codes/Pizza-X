using PizzaX.Domain.Enums.Product;

namespace PizzaX.Application.DTOs.ProductDTOs.Common
{
    public abstract class BaseCreateProductDto
    {
        public decimal Price { get; init; }
        public string? Description { get; init; }
        public StockStatus StockStatus { get; init; }
        public ProductType ProductType { get; init; }
    }
}
