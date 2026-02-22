using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.ProductDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class ProductRepository : GeneralRepository<Product>, IProductRepository
    {
        public ProductRepository(PizzaXDbContext context) : base(context) { }

        public async Task<PagedResultDto<Product>> GetAllAsync(ProductFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            if (filterDto.StockStatus.HasValue)
                query = query.Where(p => p.StockStatus == filterDto.StockStatus);

            if (filterDto.ProductType.HasValue)
                query = query.Where(p => p.ProductType == filterDto.ProductType);

            if (filterDto.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filterDto.MinPrice.Value);

            if (filterDto.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filterDto.MaxPrice.Value);

            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<Product>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
