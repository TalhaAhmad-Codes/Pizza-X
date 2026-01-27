using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.BaseCategoryDTOs;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Common;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class PizzaVarietyRepository : GeneralRepository<PizzaVariety>, IPizzaVarietyRepository
    {
        public PizzaVarietyRepository(PizzaXDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResultDto<PizzaVariety>> GetAllAsync(BaseCategoryFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            // Applying filters
            if (filterDto.Name != null)
                query = query.Where(v => v.Value == Function.Simplify(filterDto.Name, true));

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
