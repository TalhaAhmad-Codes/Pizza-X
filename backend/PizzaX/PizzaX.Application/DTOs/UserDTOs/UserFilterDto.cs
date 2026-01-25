using PizzaX.Application.DTOs.Common;
using PizzaX.Domain.Enums.User;

namespace PizzaX.Application.DTOs.UserDTOs
{
    public sealed class UserFilterDto : BaseFilterDto
    {
        // Data fields
        public string? Username { get; init; }
        public string? Email { get; init; }
        public UserRole? Role { get; init; }
    }
}
