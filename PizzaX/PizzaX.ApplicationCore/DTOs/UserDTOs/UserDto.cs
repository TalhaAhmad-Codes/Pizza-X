using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.Domain.Users.Enums;
using PizzaX.Domain.Users.ValueObjects;

namespace PizzaX.ApplicationCore.DTOs.UserDTOs
{
    public sealed class UserDto : AuditableDto
    {
        public byte[]? ProfilePic { get; init; }
        public string Username { get; init; }
        public Email Email { get; init; }
        public UserRole Role { get; init; }
        public bool IsActive { get; init; }
    }
}
