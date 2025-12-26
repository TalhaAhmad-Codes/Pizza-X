using Microsoft.EntityFrameworkCore;
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
            var query = _context.Pizzas.AsQueryable();

            // Applying filters
            if (filter.Size.HasValue)
                query = query.Where(p => p.Size == filter.Size.Value);

            if (filter.IsAvailable.HasValue)
                query = query.Where(p => p.IsAvailable == filter.IsAvailable.Value);

            if (filter.PizzaVarietyId.HasValue)
                query = query.Where(p => p.PizzaVarietyId == filter.PizzaVarietyId.Value);

            if (filter.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filter.MaxPrice.Value);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResultDto<Pizza>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
