using PizzaX.Application.DTOs.ProductDTOs;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IBaseProductService
    {
        Task<ProductDto> CreateProductAsync(Guid productId, CreateProductDto dto);
        Task<ProductDto?> GetProductByIdAsync(Guid id);
    }
}
