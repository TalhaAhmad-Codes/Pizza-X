using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesCetagoryDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class FriesCategoryRepository : GeneralRepository<FriesCategory>, IFriesCategoryRepository
    {
        public FriesCategoryRepository(PizzaXDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResultDto<FriesCategory>> GetAllAsync(FriesCategoryFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            // Applying filter
            if (filterDto.Name != null)
                query = query.Where(c => c.Name == filterDto.Name);

            // Getting paged result
            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<FriesCategory>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
