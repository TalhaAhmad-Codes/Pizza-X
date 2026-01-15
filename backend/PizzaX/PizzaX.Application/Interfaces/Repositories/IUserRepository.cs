using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.UserDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGeneralRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<PagedResultDto<User>> GetAllAsync(UserFilterDto filterDto);
    }
}
