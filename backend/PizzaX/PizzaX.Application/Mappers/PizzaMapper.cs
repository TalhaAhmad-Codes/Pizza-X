using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Application.DTOs.ProductDTOs.Common;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaDto ToDto(Pizza pizza, BaseProductDto product)
            => new()
            {
                // Pizza
                Id = pizza.Id,
                ProductId = pizza.ProductId,
                VarietyId = pizza.VarietyId,
                Size = pizza.Size,

                // Product
                Image = product.Image,
                Price = product.Price,
                Description = product.Description,
                StockStatus = product.StockStatus,
                
                CreatedAt = pizza.CreatedAt,
                UpdatedAt = pizza.UpdatedAt
            };
    }
}
