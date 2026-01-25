using PizzaX.Domain.Enums.User;

namespace PizzaX.Application.DTOs.UserDTOs
{
    public sealed class CreateUserDto
    {
        public string Username { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
        public UserRole Role { get; init; }
    }
}
