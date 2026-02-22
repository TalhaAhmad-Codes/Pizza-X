using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class PizzaRepository : BaseProductRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaXDbContext context) : base(context) { }

        public async Task<PagedResultDto<Pizza>> GetAllAsync(PizzaFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            if (filterDto.VarietyId.HasValue)
                query = query.Where(p => p.VarietyId == filterDto.VarietyId);

            if (filterDto.Size.HasValue)
                query = query.Where(p => p.Size == filterDto.Size);

            if (filterDto.MinPrice.HasValue)
                query = query.Where(p => dbSetProduct.Find(p.ProductId)!.Price >= filterDto.MinPrice.Value);

            if (filterDto.MaxPrice.HasValue)
                query = query.Where(p => dbSetProduct.Find(p.ProductId)!.Price <= filterDto.MaxPrice.Value);

            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<Pizza>()
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
