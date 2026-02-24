using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.UserDTOs;
using PizzaX.Application.DTOs.UserDTOs.UserUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<PagedResultDto<UserDto>> GetAllAsync(UserFilterDto filterDto);

        // Basic methods
        Task<UserDto?> GetByEmailAsync(string email);
        Task<UserDto?> GetByIdAsync(Guid id);
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task CreateBulkAsync(CreateBulkDto<CreateUserDto> dtos);
        Task<bool> RemoveAsync(Guid id);

        // Update methods
        Task<bool> UpdateProfilePic(UserUpdateProfilePicDto dto);
        Task<bool> UpdateUsernameAsync(UserUpdateUsernameDto dto);
        Task<bool> UpdatePasswordAsync(UserUpdatePasswordDto dto);
        Task<bool> UpdateEmailAsync(UserUpdateEmailDto dto);
    }
}
