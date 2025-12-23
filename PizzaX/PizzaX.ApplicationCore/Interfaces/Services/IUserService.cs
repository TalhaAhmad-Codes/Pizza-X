using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.UserDTOs;

namespace PizzaX.ApplicationCore.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto?> GetByEmailAsync(string email);
        Task<PagedResultDto<UserDto>> GetUsersAsync(UserFilterDto filter);
    }
}
