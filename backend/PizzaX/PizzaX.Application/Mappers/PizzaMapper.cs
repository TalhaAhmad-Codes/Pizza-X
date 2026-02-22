using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaDto ToDto(Pizza pizza, Product product)
            => new()
            {
                // Pizza
                Id = pizza.Id,
                ProductId = pizza.ProductId,
                VarietyId = pizza.VarietyId,
                Size = pizza.Size,

                // Product
                Image = product.Image,
                Price = product.Price.UnitPrice,
                Description = product.Description,
                StockStatus = product.StockStatus,
                
                CreatedAt = pizza.CreatedAt,
                UpdatedAt = pizza.UpdatedAt
            };
    }
}
