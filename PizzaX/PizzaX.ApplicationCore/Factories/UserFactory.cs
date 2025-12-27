using PizzaX.ApplicationCore.DTOs.UserDTOs;
using PizzaX.Domain.Users.Entities;
using PizzaX.Domain.Users.ValueObjects;

namespace PizzaX.ApplicationCore.Factories
{
    public static class UserFactory
    {
        public static User Create(UserDto dto)
            => User.Create(
                username: dto.Username,
                password: dto.Password,
                email: Email.Create(dto.Email),
                role: dto.Role,
                isActive: dto.IsActive
            );
    }
}
