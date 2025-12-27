using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.UserDTOs;
using PizzaX.ApplicationCore.Interfaces.Repositories;
using PizzaX.ApplicationCore.Interfaces.Services;
using PizzaX.ApplicationCore.Mappers;

namespace PizzaX.ApplicationCore.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
            => _userRepository = userRepository;

        public async Task<UserDto?> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return UserMapper.ToDto(user!);
        }

        public async Task<PagedResultDto<UserDto>> GetUsersAsync(UserFilterDto filter)
        {
            var result = await _userRepository.GetAsync(filter);

            return new PagedResultDto<UserDto>
            {
                Items = result.Items.Select(UserMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }
    }
}
