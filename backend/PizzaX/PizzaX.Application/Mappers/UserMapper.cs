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
                Password = user.Password.Hash,
                Role = user.UserRole,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
    }
}
