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
        Task<bool> UpdateUsernameAsync(UserUpdateUsernameDto dto);
        Task<bool> UpdatePasswordAsync(UserUpdatePasswordDto dto);
        Task<bool> UpdateEmailAsync(UserUpdateEmailDto dto);
    }
}
