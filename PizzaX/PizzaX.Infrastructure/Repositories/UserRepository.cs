using Microsoft.EntityFrameworkCore;
using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.UserDTOs;
using PizzaX.ApplicationCore.Interfaces.Repositories;
using PizzaX.Domain.Users.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(PizzaXDbContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
            => await _set.FirstOrDefaultAsync(u => u.Email.Value == email);

        public async Task<PagedResultDto<User>> GetAsync(UserFilterDto filter)
        {
            var query = _context.Users.AsQueryable();

            // Applying filters
            if (filter.Email is not null)
                query = query.Where(u => u.Email.Value == filter.Email);

            if (filter.Username is not null)
                query = query.Where(u => u.Username.ToLower() == filter.Username.ToLower());
            
            if (filter.Role.HasValue)
                query = query.Where(u => u.Role == filter.Role);

            if (filter.IsActive.HasValue)
                query = query.Where(u => u.IsActive == filter.IsActive);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResultDto<User>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
