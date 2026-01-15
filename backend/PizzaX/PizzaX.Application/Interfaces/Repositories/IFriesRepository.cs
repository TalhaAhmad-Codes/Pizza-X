using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IFriesRepository : IGeneralRepository<Fries>
    {
        Task<PagedResultDto<Fries>> GetAllAsync(FriesFilterDto filterDto);
    }
}
