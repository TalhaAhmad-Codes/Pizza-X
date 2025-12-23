using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.PizzaDTOs;
using PizzaX.Domain.Pizzas.Entities;

namespace PizzaX.ApplicationCore.Interfaces.Repositories
{
    public interface IPizzaRepository : IRepository<Pizza>
    {
        Task<PagedResultDto<Pizza>> GetAsync(PizzaFilterDto filter);
    }
}
