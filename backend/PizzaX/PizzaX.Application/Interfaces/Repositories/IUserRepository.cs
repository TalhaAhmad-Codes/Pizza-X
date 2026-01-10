using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.UserDTOs;
using PizzaX.Application.DTOs.UserDTOs.UserUpdateDtos;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGeneralRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<PagedResultDto<User>> GetAllAsync(UserFilterDto filterDto);

        // Update methods
        Task<User?> UpdateUsernameAsync(UserUpdateUsernameDto usernameDto);
        Task<User?> UpdateEmailAsync(UserUpdateEmailDto emailDto);
        Task<User?> UpdatePasswordAsync(UserUpdatePasswordDto passwordDto);
    }
}
