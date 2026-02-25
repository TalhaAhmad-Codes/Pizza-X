using PizzaX.Application.DTOs.UserDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
            => new()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email.Value,
                Role = user.UserRole,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };

        public static User ToEntity(CreateUserDto dto)
            => User.Create(
                username: dto.Username,
                email: dto.Email,
                password: dto.Password,
                userRole: dto.Role
            );
    }
}
