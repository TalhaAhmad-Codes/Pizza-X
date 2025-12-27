using Microsoft.EntityFrameworkCore;
using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.PizzaVarietyDTOs;
using PizzaX.ApplicationCore.Interfaces.Repositories;
using PizzaX.Domain.Pizzas.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    internal sealed class PizzaVarietyRepository : Repository<PizzaVariety>, IPizzaVarietyRepository
    {
        public PizzaVarietyRepository(PizzaXDbContext context) : base(context) { }

        public async Task<PagedResultDto<PizzaVariety>> GetAsync(PizzaVarietyFilterDto filter)
        {
            var query = _context.PizzaVarieties.AsQueryable();

            // Applying filters
            if (filter.Name is not null)
                query = query.Where(v => v.Name.ToLower() == filter.Name.ToLower());

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResultDto<PizzaVariety>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
