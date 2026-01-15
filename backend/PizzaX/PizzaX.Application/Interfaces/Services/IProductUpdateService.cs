using PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IProductUpdateService
    {
        Task<bool> UpdateImageAsync(ProductUpdateImageDto dto);
        Task<bool> UpdatePriceAsync(ProductUpdatePriceDto dto);
        Task<bool> UpdateQuantityAsync(ProductUpdateQuantityDto dto);
        Task<bool> UpdateDescriptionAsync(ProductUpdateDescriptionDto dto);
    }
}
