using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.ProductDTOs;
using PizzaX.Application.DTOs.ProductDTOs.ProductUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IProductService : IBaseProductUpdateService
    {
        Task<PagedResultDto<ProductDto>> GetAllAsync(ProductFilterDto filterDto);
        Task<ProductDto?> GetByIdAsync(Guid id);

        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateNameAsync(ProductUpdateNameDto dto);
    }
}
