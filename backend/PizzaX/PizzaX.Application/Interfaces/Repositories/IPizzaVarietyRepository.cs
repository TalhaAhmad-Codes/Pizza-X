using PizzaX.Application.DTOs.BaseCategoryDTOs;
using PizzaX.Application.DTOs.Common;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IPizzaVarietyRepository : IGeneralRepository<PizzaVariety>
    {
        Task<PagedResultDto<PizzaVariety>> GetAllAsync(BaseCategoryFilterDto filterDto);
    }
}
