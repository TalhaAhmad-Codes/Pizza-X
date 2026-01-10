using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesCetagoryDTOs;
using PizzaX.Application.DTOs.FriesCetagoryDTOs.FriesCetagoryUpdateDtos;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IFriesCategoryRepository : IGeneralRepository<FriesCategory>
    {
        Task<PagedResultDto<FriesCategory>> GetAllAsync(FriesCategoryFilterDto filterDto);

        // Update method
        Task<FriesCategory?> UpdateNameAsync(FriesCetagoryUpdateNameDto nameDto);
    }
}
