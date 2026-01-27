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
                CategoryId = product.CategoryId,
                Name = product.Name,
                Image = product.Image,
                TotalPrice = product.TotalPrice,
                UnitPrice = product.Price.UnitPrice,
                Quantity = product.Quantity.Value,
                Description = product.Description,
                StockStatus = product.StockStatus,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
    }
}
