using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.UserDTOs;
using PizzaX.Domain.Users.Entities;

namespace PizzaX.ApplicationCore.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<PagedResultDto<User>> GetAsync(UserFilterDto filter);
    }
}
