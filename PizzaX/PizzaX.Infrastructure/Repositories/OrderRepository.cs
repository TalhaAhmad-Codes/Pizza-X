using Microsoft.EntityFrameworkCore;
using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.OrderDTOs;
using PizzaX.ApplicationCore.Interfaces.Repositories;
using PizzaX.Domain.Orders.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    internal sealed class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(PizzaXDbContext context) : base(context) { }

        public async Task<Order?> GetByOrderNumberAsync(string orderNumber)
            => await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.OrderNumber.Value == orderNumber);

        public async Task<PagedResultDto<Order>> GetAsync(OrderFilterDto filter)
        {
            var query = _context.Orders.AsQueryable();

            if (filter.Status.HasValue)
                query = query.Where(o => o.Status == filter.Status.Value);

            if (filter.PaymentStatus.HasValue)
                query = query.Where(o => o.PaymentStatus == filter.PaymentStatus.Value);

            if (filter.UserId.HasValue)
                query = query.Where(o => o.UserId == filter.UserId.Value);

            if (filter.FromDate.HasValue)
                query = query.Where(o => o.CreatedAt >= filter.FromDate.Value);

            if (filter.ToDate.HasValue)
                query = query.Where(o => o.CreatedAt <= filter.ToDate.Value);

            var totalCount = await query.CountAsync();

            var items = await query
                .Include(o => o.Items)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResultDto<Order>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
