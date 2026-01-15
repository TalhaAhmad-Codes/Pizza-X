using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IDrinkRepository : IGeneralRepository<Drink>
    {
        Task<PagedResultDto<Drink>> GetAllAsync(DrinkFilterDto filterDto);
    }
}
