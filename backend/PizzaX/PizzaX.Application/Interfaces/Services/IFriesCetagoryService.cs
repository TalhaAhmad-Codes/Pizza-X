using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesCetagoryDTOs;
using PizzaX.Application.DTOs.FriesCetagoryDTOs.FriesCetagoryUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IFriesCetagoryService
    {
        Task<PagedResultDto<FriesCategoryDto>> GetAllAsync(FriesCategoryFilterDto filterDto);

        // Update method
        Task<FriesCategoryDto?> UpdateNameAsync(FriesCetagoryUpdateNameDto nameDto);
    }
}
