using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.Domain.Users.Enums;

namespace PizzaX.ApplicationCore.DTOs.UserDTOs
{
    public sealed class UserDto : AuditableDto
    {
        public byte[]? ProfilePic { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
        public UserRole? Role { get; init; }
        public bool IsActive { get; init; }
    }
}
