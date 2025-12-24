using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.PizzaDTOs;
using PizzaX.ApplicationCore.Interfaces.Repositories;
using PizzaX.Domain.Pizzas.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    internal sealed class PizzaRepository : Repository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaXDbContext context) : base(context) { }

        public async Task<PagedResultDto<Pizza>> GetAsync(PizzaFilterDto filter)
        {
            
        }
    }
}
