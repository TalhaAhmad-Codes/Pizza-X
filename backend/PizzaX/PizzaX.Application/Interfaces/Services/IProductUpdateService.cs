using PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IProductUpdateService<TDto> where TDto : class
    {
        Task<TDto?> UpdateImageAsync(ProductUpdateImageDto dto);
        Task<TDto?> UpdatePriceAsync(ProductUpdatePriceDto dto);
        Task<TDto?> UpdateQuantityAsync(ProductUpdateQuantityDto dto);
        Task<TDto?> UpdateDescriptionAsync(ProductUpdateDescriptionDto dto);
    }
}
