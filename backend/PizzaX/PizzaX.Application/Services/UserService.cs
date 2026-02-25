using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.UserDTOs;
using PizzaX.Application.DTOs.UserDTOs.UserUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
            => this.repository = repository;

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = User.Create(
                username: dto.Username,
                email: dto.Email,
                password: dto.Password,
                userRole: dto.Role
            );

            await repository.AddAsync(user);
            return UserMapper.ToDto(user);
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await repository.GetByIdAsync(id);

            return user is null ? null : UserMapper.ToDto(user);
        }

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

        public async Task<bool> RemoveAsync(Guid id)
        {
            var user = await repository.GetByIdAsync(id);

            if (user is null) return false;

            await repository.RemoveAsync(user);
            return true;
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

        public async Task<bool> UpdateProfilePic(UserUpdateProfilePicDto dto)
        {
            var user = await repository.GetByIdAsync(dto.Id);

            if (user is null) return false;

            user.UpdateProfilePic(dto.Image);
            await repository.UpdateAsync(user);
            return true;
        }

        public async Task CreateBulkAsync(CreateBulkDto<CreateUserDto> dtos)
        {
            var users = dtos.Items.Select(UserMapper.ToEntity).ToList();
            await repository.AddBulkAsync(users);
        }
    }
}
