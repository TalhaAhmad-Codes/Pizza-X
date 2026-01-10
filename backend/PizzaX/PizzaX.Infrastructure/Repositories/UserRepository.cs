using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.UserDTOs;
using PizzaX.Application.DTOs.UserDTOs.UserUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Common.Exceptions;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class UserRepository : GeneralRepository<User>, IUserRepository
    {
        public UserRepository(PizzaXDbContext dbContext) : base(dbContext) { }

        public async Task<User?> GetByEmailAsync(string email)
            => await dbSet.FirstOrDefaultAsync(u => u.Email.Value == email);

        public async Task<PagedResultDto<User>> GetAllAsync(UserFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            // Applying filters
            if (filterDto.Username is not null)
                query = query.Where(u => u.Username == filterDto.Username);

            if (filterDto.Email is not null)
                query = query.Where(u => u.Email.Value == filterDto.Email);

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

        // Update methods
        public async Task<User?> UpdateUsernameAsync(UserUpdateUsernameDto usernameDto)
        {
            var user = await GetByIdAsync(usernameDto.Id);
            
            if (user != null)
            {
                user.UpdateUsername(usernameDto.Username);
                await UpdateAsync(user);
            }
            
            return user;
        }

        public async Task<User?> UpdateEmailAsync(UserUpdateEmailDto emailDto)
        {
            var user = await GetByIdAsync(emailDto.Id);
            
            if (user != null)
            {
                user.UpdateEmail(emailDto.Password, emailDto.Email);
                await UpdateAsync(user);
            }

            return user;
        }

        public async Task<User?> UpdatePasswordAsync(UserUpdatePasswordDto passwordDto)
        {
            var user = await GetByIdAsync(passwordDto.Id);

            if (user != null)
            {
                if (passwordDto.NewPassword != passwordDto.ConfirmPassword)
                    throw new InvalidCredentialsException("The new password didn't match the credentials.");

                user.UpdatePassword(passwordDto.OldPassword, passwordDto.NewPassword);
                await UpdateAsync(user);
            }

            return user;
        }
    }
}
