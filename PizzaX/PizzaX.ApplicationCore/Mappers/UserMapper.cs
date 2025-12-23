using PizzaX.ApplicationCore.DTOs.UserDTOs;
using PizzaX.Domain.Users.Entities;

namespace PizzaX.ApplicationCore.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
            => new() {
                Id = user.Id,
                ProfilePic = user.ProfilePic,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
    }
}
