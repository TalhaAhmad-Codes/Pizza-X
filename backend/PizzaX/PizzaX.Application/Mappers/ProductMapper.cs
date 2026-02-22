using PizzaX.Application.DTOs.ProductDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(Product product)
            => new()
            {
                Id = product.Id,
                Image = product.Image,
                Price = product.Price.UnitPrice,
                Description = product.Description,
                StockStatus = product.StockStatus,
                ProductType = product.ProductType,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
    }
}
