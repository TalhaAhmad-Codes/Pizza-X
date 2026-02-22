using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.UserDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Common;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class UserRepository : GeneralRepository<User>, IUserRepository
    {
        public UserRepository(PizzaXDbContext dbContext) : base(dbContext) { }

        public async Task<User?> GetByEmailAsync(string email)
            => await dbSet.FirstOrDefaultAsync(u => u.Email.Value == Function.Simplify(email));

        public async Task<PagedResultDto<User>> GetAllAsync(UserFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            // Applying filters
            if (filterDto.Username is not null)
                query = query.Where(u => u.Username == Function.Simplify(filterDto.Username, true));

            if (filterDto.Email is not null)
                query = query.Where(u => u.Email.Value == Function.Simplify(filterDto.Email));

            if (filterDto.Role.HasValue)
                query = query.Where(u => u.UserRole == filterDto.Role);

            // Getting paged result
            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<User>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
