using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesDTOs;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IFriesService : IProductUpdateService<FriesDto>
    {
        Task<PagedResultDto<FriesDto>> GetAllAsync(FriesFilterDto filterDto);
    }
}
