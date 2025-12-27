using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.PizzaVarietyDTOs;
using PizzaX.Domain.Pizzas.Entities;

namespace PizzaX.ApplicationCore.Interfaces.Repositories
{
    public interface IPizzaVarietyRepository : IRepository<PizzaVariety>
    {
        Task<PagedResultDto<PizzaVariety>> GetAsync(PizzaVarietyFilterDto filter);
    }
}
