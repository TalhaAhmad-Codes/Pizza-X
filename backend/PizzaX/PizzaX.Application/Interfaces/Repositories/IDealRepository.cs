using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DealDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IDealRepository : IGeneralRepository<Deal>
    {
        Task<PagedResultDto<Deal>> GetAllAsync(DealFilterDto filterDto);
    }
}
