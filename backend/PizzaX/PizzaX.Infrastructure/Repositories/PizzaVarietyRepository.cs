using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaVarietyDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class PizzaVarietyRepository : GeneralRepository<PizzaVariety>, IPizzaVarietyRepository
    {
        public PizzaVarietyRepository(PizzaXDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResultDto<PizzaVariety>> GetAllAsync(PizzaVarietyFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            // Applying filters
            if (filterDto.Name != null)
                query = query.Where(v => v == filterDto.Name);

            // Pagination
            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<PizzaVariety>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
