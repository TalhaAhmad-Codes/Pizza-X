using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.UserDTOs;
using PizzaX.Application.DTOs.UserDTOs.UserUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;

namespace PizzaX.Application.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
            => this.repository = repository;

        public async Task<PagedResultDto<UserDto>> GetAllAsync(UserFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<UserDto>
            {
                Items = result.Items.Select(UserMapper.ToDto).ToList(),
                TotalCount = result.TotalCount,
            };
        }

        public async Task<UserDto?> GetByEmailAsync(string email)
        {
            var user = await repository.GetByEmailAsync(email);

            return user is null ? null : UserMapper.ToDto(user);
        }

        public async Task<bool> UpdateEmailAsync(UserUpdateEmailDto dto)
        {
            var user = await repository.GetByIdAsync(dto.Id);

            if (user is null) return false;

            user.UpdateEmail(dto.Password, dto.Email);
            await repository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> UpdatePasswordAsync(UserUpdatePasswordDto dto)
        {
            var user = await repository.GetByIdAsync(dto.Id);

            if (user is null) return false;

            user.UpdatePassword(dto.OldPassword, dto.NewPassword, dto.ConfirmPassword);
            await repository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> UpdateUsernameAsync(UserUpdateUsernameDto dto)
        {
            var user = await repository.GetByIdAsync(dto.Id);

            if (user is null) return false;

            user.UpdateUsername(dto.Username);
            await repository.UpdateAsync(user);
            return true;
        }
    }
}
