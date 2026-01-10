using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.UserDTOs;
using PizzaX.Application.DTOs.UserDTOs.UserUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto?> GetByEmailAsync(string email);
        Task<PagedResultDto<UserDto>> GetAllAsync(UserFilterDto filterDto);

        // Update methods
        Task<UserDto?> UpdateUsernameAsync(UserUpdateUsernameDto usernameDto);
        Task<UserDto?> UpdatePasswordAsync(UserUpdatePasswordDto passwordDto);
        Task<UserDto?> UpdateEmailAsync(UserUpdateEmailDto emailDto);
    }
}
