using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesDTOs;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IFriesService : IProductUpdateService
    {
        Task<PagedResultDto<FriesDto>> GetAllAsync(FriesFilterDto filterDto);

        // Basic methods
        Task<FriesDto?> GetByIdAsync(Guid id);
        Task<FriesDto> CreateAsync(CreateFriesDto dto);
        Task<bool> RemoveAsync(Guid id);
    }
}
